using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class RideMSSQLContext : IRideContext
    {
        private readonly string _connectionstring;
        private string _query;
        private string _procedure;

        public RideMSSQLContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public IEnumerable<Ride> All()
        {
            throw new System.NotImplementedException();
        }

        public Ride GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Ride entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Ride entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ride> GetAllRides()
        {
            List<Ride> rides = new List<Ride>();
            this._query = "SELECT Ride.Id as RId, Ride.StartDate, Vehicles.Id as VId, Vehicles.Brand, Vehicles.Type, Vehicles.Fuel, Vehicles.LicensePlate, Vehicles.Length, Vehicles.Width, Vehicles.Height, Account.Id as AId, Account.FirstName, Account.LastName, Rcount = (SELECT COUNT(*) FROM PickOrder WHERE PickOrder.VehicleId = Ride.VehicleId)  FROM Ride INNER JOIN Vehicles on Ride.VehicleId = Vehicles.Id INNER JOIN Account on Ride.AccountId = Account.Id";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        Ride ride = new Ride()
                        {
                            Id = record.GetInt32(record.GetOrdinal("RId")),
                            RideDate = record.GetDateTime(record.GetOrdinal("StartDate")),
                            Vehicle = new Vehicle()
                            {
                                Id = record.GetInt32(record.GetOrdinal("VId")),
                                Brand = record.GetString(record.GetOrdinal("Brand")),
                                Type = record.GetString(record.GetOrdinal("Type")),
                                Fuel = record.GetString(record.GetOrdinal("Fuel")),
                                LicensePlate = record.GetString(record.GetOrdinal("LicensePlate")),
                                Length = record.GetDouble(record.GetOrdinal("Length")),
                                Width = record.GetDouble(record.GetOrdinal("Width")),
                                Height = record.GetDouble(record.GetOrdinal("Height")),
                            },
                            Account = new Account()
                            {
                                Id = record.GetInt32(record.GetOrdinal("AId")),
                                FirstName = record.GetString(record.GetOrdinal("FirstName")),
                                LastName = record.GetString(record.GetOrdinal("LastName")),
                            },
                            AmountOfPickOrders = record.GetInt32(record.GetOrdinal("Rcount")),
                        };

                        rides.Add(ride);
                    }
                    return rides;
                }
            }
        }
    }
}