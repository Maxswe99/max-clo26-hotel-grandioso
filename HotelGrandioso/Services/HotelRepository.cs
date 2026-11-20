namespace HotelGrandioso.Services;

using HotelGrandioso.Data;
using HotelGrandioso.Models;
using Microsoft.EntityFrameworkCore;


public class HotelRepository
{
    private HotelContext Context;

    public HotelRepository(HotelContext context)
    {
        Context = context;
    }
}