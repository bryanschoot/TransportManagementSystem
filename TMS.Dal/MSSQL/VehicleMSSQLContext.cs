using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using TMS.Dal.Interface;
using TMS.Model;

namespace TMS.Dal.MSSQL
{
    public class VehicleMSSQLContext : IVehicleContext
    {
        private readonly string _connectionstring;
        private string _query;

        public VehicleMSSQLContext(string connectionstring)
        {
            this._connectionstring = connectionstring;
        }

        public IEnumerable<Vehicle> All()
        {
            this._query = "SELECT Vehicles.Id, Vehicles.Brand, Vehicles.Type, Vehicles.Fuel, Vehicles.LicensePlate, Vehicles.Length, Vehicles.Width, Vehicles.Height FROM Vehicles";
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        Vehicle vehicle = new Vehicle()
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            Brand = record.GetString(record.GetOrdinal("Brand")),
                            Type = record.GetString(record.GetOrdinal("Type")),
                            Fuel = record.GetString(record.GetOrdinal("Fuel")),
                            LicensePlate = record.GetString(record.GetOrdinal("LicensePlate")),
                            Length = record.GetDouble(record.GetOrdinal("Length")),
                            Width = record.GetDouble(record.GetOrdinal("Width")),
                            Height = record.GetDouble(record.GetOrdinal("Height")),
                        };
                        vehicles.Add(vehicle);
                    }
                    return vehicles;
                }
            }
        }

        public Vehicle GetById(int id)
        {
            this._query = "SELECT Vehicles.Id, Vehicles.Brand, Vehicles.Type, Vehicles.Fuel, Vehicles.LicensePlate, Vehicles.Length, Vehicles.Width, Vehicles.Height FROM Vehicles WHERE Vehicles.Id = @Id";
            Vehicle vehicle = null;

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        vehicle = new Vehicle()
                        {
                            Id = record.GetInt32(record.GetOrdinal("Id")),
                            Brand = record.GetString(record.GetOrdinal("Brand")),
                            Type = record.GetString(record.GetOrdinal("Type")),
                            Fuel = record.GetString(record.GetOrdinal("Fuel")),
                            LicensePlate = record.GetString(record.GetOrdinal("LicensePlate")),
                            Length = record.GetDouble(record.GetOrdinal("Length")),
                            Width = record.GetDouble(record.GetOrdinal("Width")),
                            Height = record.GetDouble(record.GetOrdinal("Height")),
                        };
                    }
                    return vehicle;
                }
            }
        }

        public bool Exists(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Vehicle entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Vehicle vehicle)
        {
            this._query = "UPDATE Vehicles SET Brand = @Brand, Type = @Type, Fuel = @Fuel, LicensePlate = @LicensePlate, Length = @Length, Width = @Width, Height = @Height WHERE Vehicles.Id = @Id";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", vehicle.Id);
                    cmd.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                    cmd.Parameters.AddWithValue("@Fuel", vehicle.Fuel);
                    cmd.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@Length", vehicle.Length);
                    cmd.Parameters.AddWithValue("@Width", vehicle.Width);
                    cmd.Parameters.AddWithValue("@Height", vehicle.Height);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        public bool Delete(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public int Count(Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            this._query = "INSERT INTO Vehicles (Brand, Type, Fuel, LicensePlate, Length, Width, Height) VALUES (@Brand, @Type, @Fuel, @LicensePlate, @Length, @Width, @Height)";

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                    cmd.Parameters.AddWithValue("@Fuel", vehicle.Fuel);
                    cmd.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@Length", vehicle.Length);
                    cmd.Parameters.AddWithValue("@Width", vehicle.Width);
                    cmd.Parameters.AddWithValue("@Height", vehicle.Height);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        public int CountAllVehicles()
        {
            this._query = "SELECT COUNT (*) FROM Vehicles";
            int total = 0;

            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(this._query, conn))
                {
                    conn.Open();
                    return (Int32)cmd.ExecuteScalar();
                }
            }
        }
    }
}