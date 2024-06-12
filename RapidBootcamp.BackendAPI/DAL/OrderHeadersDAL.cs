﻿using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModels;
using System.Data.SqlClient;
using System.Transactions;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeadersDAL : IOrderHeaders
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private readonly IOrderDetail _orderDetail;
        private SqlConnection _connection;
        private readonly IWallet _wallet;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderHeadersDAL(IConfiguration config, IOrderDetail orderDetail, IWallet wallet)
        {
            _config = config;
            _orderDetail = orderDetail;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
            _wallet = wallet;
        }

        public OrderHeader Add(OrderHeader entity)
        {
            TransactionManager.ImplicitDistributedTransactions = true;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    string lastOrderHeaderId = GetOrderLastHeaderId();

                    lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                    int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                    string newOrderHeaderIdString = "INV-" + newOrderHeaderId.ToString().PadLeft(4, '0');
                    entity.OrderHeaderId = newOrderHeaderIdString;

                    string query = @"insert into OrderHeaders (OrderHeaderId, WalletId) 
                                 values (@OrderHeaderId, @WalletId)";
                    _command = new SqlCommand(query, _connection);
                    _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                    _command.Parameters.AddWithValue("@WalletId", entity.WalletId);
                    _connection.Open();
                    _command.ExecuteNonQuery();

                    // tambah item detail produck yng dijual
                    if (entity.OrderDetails != null)
                    {
                        foreach (var item in entity.OrderDetails)
                        {
                            item.OrderHeaderId = newOrderHeaderIdString;
                            _orderDetail.Add(item);
                        }
                    }

                    // cek wallet saldo
                    decimal saldo = _wallet.GetWalletSaldo(entity.WalletId);
                    decimal total = _orderDetail.GetTotalAmount(newOrderHeaderIdString);

                    if (saldo < total)
                    {
                        throw new ArgumentException("Saldo Tidak Mencukupi");
                    }
                    //update saldo wallet
                    saldo -= total;
                    _wallet.UpdateWalletSaldo(entity.WalletId, saldo);



                    scope.Complete();

                    return entity;
                }
                catch (TransactionException transEx)
                {
                    throw new ArgumentException(transEx.Message);
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    scope.Dispose();
                    _command.Dispose();
                    _connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            try
            {
                List<OrderHeader> orderHeaders = new List<OrderHeader>();
                string query = @"select * from ViewOrderHeaderInfo 
                                 order by OrderHeaderId desc";

                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        orderHeaders.Add(new OrderHeader
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString(),
                            TransactionDate = Convert.ToDateTime(_reader["TransactionDate"]),
                            Wallet = new Wallet
                            {
                                CustomerId = Convert.ToInt32(_reader["CustomerId"]),
                                Customer = new Customer
                                {
                                    CustomerName = _reader["CustomerName"].ToString()
                                },
                                WalletType = new WalletType
                                {
                                    WalletName = _reader["WalletName"].ToString()
                                }
                            }
                        });
                    }
                }
                _reader.Close();
                return orderHeaders;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            try
            {
                List<ViewOrderHeaderInfo> viewOrderHeaderInfos = new List<ViewOrderHeaderInfo>();
                string query = @"select * from ViewOrderHeaderInfo 
                                 order by OrderHeaderId desc";

                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        viewOrderHeaderInfos.Add(new ViewOrderHeaderInfo
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString(),
                            CustomerId = Convert.ToInt32(_reader["CustomerId"]),
                            CustomerName = _reader["CustomerName"].ToString(),
                            WalletName = _reader["WalletName"].ToString(),
                            TransactionDate = Convert.ToDateTime(_reader["TransactionDate"])
                        });
                    }
                }
                _reader.Close();
                return viewOrderHeaderInfos;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public string GetOrderLastHeaderId()
        {
            string query = @"select top 1 OrderHeaderId from OrderHeaders 
                             order by OrderHeaderId desc";
            try
            {
                _command = new SqlCommand(query, _connection);
                _connection.Open();
                var lastOrderHeaderId = _command.ExecuteScalar().ToString();
                if (lastOrderHeaderId == null)
                {
                    throw new ArgumentException("OrderHeaderId not found");
                }
                return lastOrderHeaderId;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}