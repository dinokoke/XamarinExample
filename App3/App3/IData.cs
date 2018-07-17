using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    public interface IData 
    {
        [Get("/api/v1/products.json?brand={brand}")]
        Task<List<MakeUp>> GetMakeUps(string brand);
    }
}
