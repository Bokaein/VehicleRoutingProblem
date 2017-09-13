using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models;
using VehicleRoutingProblem.Data;
using VehicleRoutingProblem.Models.ProfileViewModel;
using VehicleRoutingProblem.BusinessLayer.Profile;


namespace VehicleRoutingProblem.DataAccesslayer
{
    public class User : IUser,IDisposable

    {
        private VRPDbContext context;

        public User(VRPDbContext context)
        {
            this.context = context;
        }

      

        public IEnumerable<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Users user)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        public string FristName { get ; set; }
        public string LastName { get; set; }
        public string Email { get; set ; }
        public string PhoneNumber { get; set ; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }    

        void  IUser.GetUserByID(int UserId)
        {
            var user=context.Users.FirstOrDefault();

            this.FristName = "Mohammad";// user.FristName;
            this.LastName = "Mohammad";// user.LastName;
           
        }
    }
}
