using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManeger.DTO
{
    class ProductDTO
    {
        public ProductDTO(int id, string name , float price , int quantity , int cateId)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.cateId = cateId;
        }
        public ProductDTO()
        {

        }
       
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public int cateId { get; set; }
        public string cateName { get; set; }
    }
}
