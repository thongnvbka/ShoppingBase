using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ShoppingBase.Data.Enums;
using ShoppingBase.Data.Interfaces;
using ShoppingBase.Infrastructure.SharedKernel;

namespace ShoppingBase.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public Product() {
            ProductTags = new List<ProductTag>();
        }

        public Product(string name, int categoryId, string thumbnailImage,
            decimal price, decimal originalPrice, decimal? promotionPrice,
            string description, string content, bool? homeFlag, bool? hotFlag,
            string tags, string unit, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription,string giongnho, string typeruou,string mauruou,string country, string region ,string thoigian, string dungtich, double nongdo, string temperature)
        {
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            GiongNho = giongnho;
            TypeRuou = typeruou;
            MauRuou = mauruou;
            Country = country;
            Region = region;
            DungTich = dungtich;
            NongDo = nongdo;
            ThoiGian = thoigian;
            Temperature = temperature;
            ProductTags = new List<ProductTag>();

        }

        public Product(int id, string name, int categoryId, string thumbnailImage,
             decimal price, decimal originalPrice, decimal? promotionPrice,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, string unit, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription, string giongnho, string typeruou, string mauruou, string country, string region, string thoigian, string dungtich, double nongdo,string temperature)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            GiongNho = giongnho;
            TypeRuou = typeruou;
            MauRuou = mauruou;
            Country = country;
            Region = region;
            DungTich = dungtich;
            NongDo = nongdo;
            ThoiGian = thoigian;
            Temperature = temperature;
            ProductTags = new List<ProductTag>();

        }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }

        public string SeoPageTitle {set;get;}

        [StringLength(255)]
        public string SeoAlias {set;get;}

        [StringLength(255)]
        public string SeoKeywords {set;get;}

        [StringLength(255)]
        public string SeoDescription {set;get;}

        public DateTime DateCreated {set;get;}
        public DateTime DateModified {set;get;}

        public Status Status {set;get;}

        public string GiongNho { get; set; }
        public string TypeRuou { get; set; }
        public string MauRuou { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string ThoiGian { get; set; }

        public string DungTich { get; set; }
        public double NongDo { get; set; }
        public string Temperature { get; set; }
    }
}
