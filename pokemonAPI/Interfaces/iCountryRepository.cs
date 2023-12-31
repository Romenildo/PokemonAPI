﻿using pokemonAPI.Model;

namespace pokemonAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountrybyOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryID);
        bool CountryExists(int id);
    }
}
