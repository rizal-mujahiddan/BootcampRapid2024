
using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class WalletsDAL : IWallet
    {

        private string? _connectionString;
        private readonly IWallet _wallet;
        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public WalletsDAL(IConfiguration config, IWallet wallet)
        {
            _wallet = wallet;
            _config = config;
        }
        public IWallet Add(IWallet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWallet> GetAll()
        {
            throw new NotImplementedException();
        }

        public IWallet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal GetWalletSaldo(int walletId)
        {
            try
            {
                string query = @"SELECT Saldo FROM Wallets
                                WHERE WalletId=@WalletId";
                _command = new SqlCommand(query,_connection);
                _command.Parameters.AddWithValue("@WalletId",walletId);
                _connection.Open();
                decimal saldo = Convert.ToDecimal(_command.ExecuteScalar());
                return saldo;
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

        public IWallet Update(IWallet entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateWalletSaldo(int walletId, decimal amount)
        {
            try
            {
                var query = @"UPDATE Wallets SET Saldo=@Saldo WHERE WalletId=@WalletId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@WalletId", walletId);
                _command.Parameters.AddWithValue("@Saldo", amount);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally { 
                _command.Dispose();
                _connection.Close();
            }
        }

        IEnumerable<Wallet> ICrud<Wallet>.GetAll()
        {
            throw new NotImplementedException();
        }

        Wallet ICrud<Wallet>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Wallet Add(Wallet entity)
        {
            throw new NotImplementedException();
        }

        public Wallet Update(Wallet entity)
        {
            throw new NotImplementedException();
        }
    }
}
