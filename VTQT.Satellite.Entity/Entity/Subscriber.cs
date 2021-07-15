using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Entity.Entity
{
    public partial class Subscriber
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50,ErrorMessage ="Max Length is 50")]
        
        public string ReferenceId { get; set; }


        [MaxLength(50, ErrorMessage = "Max Length is 50")]

        public string SubscriberCode { get; set; }


        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [EnumDataType(typeof(Status))]

        public string Status { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        public string ContractNo { get; set; }

        [MaxLength(100, ErrorMessage = "Max Length is 100")]
        public string CustomerName { get; set; }


        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        public string ShipPlateNo { get; set; }


        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        public string CustomerMobile { get; set; }


        [MaxLength(225, ErrorMessage = "Max Length is 225")]
        public string CustomerAddress { get; set; }


        [MaxLength(100, ErrorMessage = "Max Length is 100")]
        public string Province { get; set; }


        [MaxLength(100, ErrorMessage = "Max Length is 100")]
        public string District { get; set; }


        [MaxLength(100, ErrorMessage = "Max Length is 100")]
        public string PaymentCycleRegisted { get; set; }

   
        public int? DataCapacity { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal? MonthlyBillingAmount { get; set; }


        [Column(TypeName = "decimal(15,2)")]
        public decimal? SuspendFee { get; set; }


        [Column(TypeName = "decimal(15,2)")]
        public decimal? ActiveFee { get; set; }


        [Column(TypeName = "decimal(15,2)")]
        public decimal? ReActiveFee { get; set; }


        public DateTime? ContractDate { get; set; }


        public DateTime? ContractDueDate { get; set; }


        public DateTime? BillingStartDate { get; set; }


        public DateTime? BillingDueDate { get; set; }


        public DateTime? LastSync { get; set; }


        [MaxLength(100, ErrorMessage = "Max Length is 100")]
        public string Provider { get; set; }


    }
    public enum Status
    {
        ACTIVED, SUSPEND,DEACTIVE
    }
}

