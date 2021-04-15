using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;

namespace OriginFinancial.CodingChallenge.AppService.AppService
{
    public class CustomerAppService : ICustomerAppService
    {
        /// <summary>
        /// The method that converts the properties values from the view model to the data model.
        /// </summary>
        /// <param name="customer">The object as view model.</param>
        /// <returns>A <see cref="Customer"/> object created from the view model.</returns>
        public Customer ViewToData(CustomerViewModel customer)
        {
            try
            {
                return new Customer
                {
                    Age = customer.Age,
                    Dependents = customer.Dependents,
                    Email = customer.Email,
                    FullName = customer.FullName,
                    House = customer.House.HasValue ? customer.House.Value : 0,
                    HouseOwnershipStatusID = customer.HouseOwnershipStatusID,
                    MaritalStatusID = customer.MaritalStatusID,
                    Income = customer.Income,
                    Vehicle = customer.Vehicle.HasValue ? customer.Vehicle.Value : 0,
                    VehicleYear = customer.VehicleYear
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
