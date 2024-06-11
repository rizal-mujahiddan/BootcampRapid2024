using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModels;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeadersDAL : IOrderHeaders
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderHeadersDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public OrderHeader Add(OrderHeader entity)
        {
            try
            {
                string query = @"INSERT INTO OrderHeaders (OrderHeaderId, WalletId)
                                VALUES (@OrderHeaderId,@WalletId)";
                
                
                _command = new SqlCommand(query,_connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                _command.Parameters.AddWithValue("@WalletId", entity.WalletId);

                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader == null) {
                    throw new ArgumentException("Data Cant be Insert");
                }
                return entity;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
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
                List<OrderHeader> orderheaders = new List<OrderHeader>();
                string query = @"SELECT * FROM ViewOrderHeaderInfo
                                 ORDER BY OrderHeaderId DESC";
                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        orderheaders.Add(new OrderHeader
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString(),
                            TransactionDate = Convert.ToDateTime(_reader["TransactionDate"]),
                            //WalletId = Convert.ToInt32(_reader["WalletId"]),
                            Wallet = new Wallet() { 
                                CustomerId = Convert.ToInt32(_reader["CustomerId"]),
                                Customer = new Customer { 
                                    CustomerName = _reader["CustomerName"].ToString()
                                },
                                WalletType = new WalletType { 
                                    WalletName = _reader["WalletName"].ToString()
                                }
                            }
                        });
                    }
                }
                _reader.Close();
                return orderheaders;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Dispose();
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
                string query = @"Select * from ViewOrderHeaderInfo
                             ORDER BY CustomerId";
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
            try
            {
                string query = @"SELECT TOP 1 OrderHeaderId from OrderHeaders 
                                 ORDER BY OrderHeaderId desc";
                _command = new SqlCommand(query,_connection);
                _connection.Open();
                var lastOrderHeaderId = _command.ExecuteScalar().ToString();
                if (lastOrderHeaderId == null)
                {
                    throw new ArgumentException("OrderHeader not Found");
                }
                return lastOrderHeaderId;
            }
            catch (SqlException SqlEx)
            {
                throw new ArgumentException(SqlEx.Message);
            }
            finally { 
                _command.Dispose();
                _connection.Close();
            }
        }
    }
}
