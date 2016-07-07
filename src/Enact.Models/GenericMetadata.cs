using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Models
{
    public abstract class GenericMetadata
    {
        public int Id { get; set; }
        public int LastEditedByUserId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }

        internal static TFakeType Fake<TFakeType>(int? id = null) where TFakeType : GenericMetadata, new()
        {
            var rng = new Random(1000);
            var item = new TFakeType();
            item.Id = id.GetValueOrDefault(rng.Next());
            item.LastEditedByUserId = 10;
            item.CreatedByUserId = 10;
            item.CreateDate = DateTime.Now.AddDays(-10);
            item.LastEditDate = DateTime.Now.AddDays(-1);
            return item;
        }
    }
}
