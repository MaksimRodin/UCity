using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UCity.Data.Models.ServiceModels
{
    [Keyless]
    [NotMapped]
    public class PointD
    {
        public double x { get; set; }
        public double y { get; set; }
        public PointD(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}