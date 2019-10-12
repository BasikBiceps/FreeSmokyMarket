using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSmokyMarket.Models;

namespace FreeSmokyMarket
{
    public static class SampleData
    {
        public static void Initialize(FreeSmokyMarketContext ctx)
        {
            if (!ctx.Tabaccos.Any())
            {
                ctx.Tabaccos.AddRange(
                    new Tabacco
                    {
                        Name = "Fumary",
                        Price = 200
                    },
                    new Tabacco
                    {
                        Name = "Dark side",
                        Price = 500
                    },
                    new Tabacco
                    {
                        Name = "Sherbet",
                        Price = 80
                    }
                    );

                ctx.SaveChanges();
            }
        }
    }
}
