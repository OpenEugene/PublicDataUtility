using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using OE.PDU.Module.LittleHelpBook.Models;

namespace OE.PDU.Module.LittleHelpBook.Repository
{
    public interface ILittleHelpBookRepository
    {
        // Providers
        IEnumerable<Provider> GetProviders();
        Provider GetProvider(int providerId);
        Provider AddProvider(Provider provider);
        Provider UpdateProvider(Provider provider);
        void DeleteProvider(int providerId);

        // Addresses
        IEnumerable<Address> GetAddresses(int providerId);
        Address GetAddress(int addressId);
        Address AddAddress(Address address);
        Address UpdateAddress(Address address);
        void DeleteAddress(int addressId);

        // Attributes
        IEnumerable<LhbAttribute> GetAttributes();
        LhbAttribute GetAttribute(int attributeId);
        LhbAttribute AddAttribute(LhbAttribute attribute);
        LhbAttribute UpdateAttribute(LhbAttribute attribute);
        void DeleteAttribute(int attributeId);

        // Phone Numbers
        IEnumerable<PhoneNumber> GetPhoneNumbers(int providerId);
        PhoneNumber GetPhoneNumber(int phoneNumberId);
        PhoneNumber AddPhoneNumber(PhoneNumber phoneNumber);
        PhoneNumber UpdatePhoneNumber(PhoneNumber phoneNumber);
        void DeletePhoneNumber(int phoneNumberId);

        // Provider Attributes
        IEnumerable<ProviderAttribute> GetProviderAttributes(int providerId);
        ProviderAttribute AddProviderAttribute(ProviderAttribute providerAttribute);
        void DeleteProviderAttribute(int providerAttributeId);

        // Views
        IEnumerable<CategoryView> GetCategories();
        IEnumerable<SubCategoryView> GetSubCategories(int categoryId);
        IEnumerable<ProviderWithCatsView> GetProvidersWithCats();
    }

    public class LittleHelpBookRepository : ILittleHelpBookRepository, ITransientService
    {
        private readonly IDbContextFactory<LittleHelpBookContext> _factory;

        public LittleHelpBookRepository(IDbContextFactory<LittleHelpBookContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Provider> GetProviders()
        {
            using var db = _factory.CreateDbContext();
            return db.Providers.Where(p => p.IsActive).ToList();
        }

        public Provider GetProvider(int providerId)
        {
            using var db = _factory.CreateDbContext();
            return db.Providers.Find(providerId);
        }

        public Provider AddProvider(Provider provider)
        {
            using var db = _factory.CreateDbContext();
            db.Providers.Add(provider);
            db.SaveChanges();
            return provider;
        }

        public Provider UpdateProvider(Provider provider)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(provider).State = EntityState.Modified;
            db.SaveChanges();
            return provider;
        }

        public void DeleteProvider(int providerId)
        {
            using var db = _factory.CreateDbContext();
            var provider = db.Providers.Find(providerId);
            db.Providers.Remove(provider);
            db.SaveChanges();
        }

        public IEnumerable<Address> GetAddresses(int providerId)
        {
            using var db = _factory.CreateDbContext();
            return db.Addresses.Where(a => a.ProviderId == providerId).ToList();
        }

        public Address GetAddress(int addressId)
        {
            using var db = _factory.CreateDbContext();
            return db.Addresses.Find(addressId);
        }

        public Address AddAddress(Address address)
        {
            using var db = _factory.CreateDbContext();
            db.Addresses.Add(address);
            db.SaveChanges();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
            return address;
        }

        public void DeleteAddress(int addressId)
        {
            using var db = _factory.CreateDbContext();
            var address = db.Addresses.Find(addressId);
            db.Addresses.Remove(address);
            db.SaveChanges();
        }

        public IEnumerable<LhbAttribute> GetAttributes()
        {
            using var db = _factory.CreateDbContext();
            return db.Attributes.ToList();
        }

        public LhbAttribute GetAttribute(int attributeId)
        {
            using var db = _factory.CreateDbContext();
            return db.Attributes.Find(attributeId);
        }

        public LhbAttribute AddAttribute(LhbAttribute attribute)
        {
            using var db = _factory.CreateDbContext();
            db.Attributes.Add(attribute);
            db.SaveChanges();
            return attribute;
        }

        public LhbAttribute UpdateAttribute(LhbAttribute attribute)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(attribute).State = EntityState.Modified;
            db.SaveChanges();
            return attribute;
        }

        public void DeleteAttribute(int attributeId)
        {
            using var db = _factory.CreateDbContext();
            var attribute = db.Attributes.Find(attributeId);
            db.Attributes.Remove(attribute);
            db.SaveChanges();
        }

        public IEnumerable<PhoneNumber> GetPhoneNumbers(int providerId)
        {
            using var db = _factory.CreateDbContext();
            return db.PhoneNumbers.Where(p => p.ProviderId == providerId).ToList();
        }

        public PhoneNumber GetPhoneNumber(int phoneNumberId)
        {
            using var db = _factory.CreateDbContext();
            return db.PhoneNumbers.Find(phoneNumberId);
        }

        public PhoneNumber AddPhoneNumber(PhoneNumber phoneNumber)
        {
            using var db = _factory.CreateDbContext();
            db.PhoneNumbers.Add(phoneNumber);
            db.SaveChanges();
            return phoneNumber;
        }

        public PhoneNumber UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(phoneNumber).State = EntityState.Modified;
            db.SaveChanges();
            return phoneNumber;
        }

        public void DeletePhoneNumber(int phoneNumberId)
        {
            using var db = _factory.CreateDbContext();
            var phoneNumber = db.PhoneNumbers.Find(phoneNumberId);
            db.PhoneNumbers.Remove(phoneNumber);
            db.SaveChanges();
        }

        public IEnumerable<ProviderAttribute> GetProviderAttributes(int providerId)
        {
            using var db = _factory.CreateDbContext();
            return db.ProviderAttributes.Where(pa => pa.ProviderId == providerId).ToList();
        }

        public ProviderAttribute AddProviderAttribute(ProviderAttribute providerAttribute)
        {
            using var db = _factory.CreateDbContext();
            db.ProviderAttributes.Add(providerAttribute);
            db.SaveChanges();
            return providerAttribute;
        }

        public void DeleteProviderAttribute(int providerAttributeId)
        {
            using var db = _factory.CreateDbContext();
            var pa = db.ProviderAttributes.Find(providerAttributeId);
            db.ProviderAttributes.Remove(pa);
            db.SaveChanges();
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            using var db = _factory.CreateDbContext();
            return db.CategoryViews.ToList();
        }

        public IEnumerable<SubCategoryView> GetSubCategories(int categoryId)
        {
            using var db = _factory.CreateDbContext();
            return db.SubCategoryViews.Where(s => s.CategoryId == categoryId).ToList();
        }

        public IEnumerable<ProviderWithCatsView> GetProvidersWithCats()
        {
            using var db = _factory.CreateDbContext();
            return db.ProviderWithCatsViews.ToList();
        }
    }
}
