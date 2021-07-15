using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Entity.Entity
{
    public partial class Subscriber
    {
        [Key]
        [Index]
        public int Id { get; set; }

        [MaxLength(50,ErrorMessage ="Max Length is 50")]
        public string ReferenceId { get; set; }
        public string SubscriberCode { get; set; }
        public Status Status { get; set; }
        public string ContractNo { get; set; }
        public string CustomerName { get; set; }
        public string ShipPlateNo { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string PaymentCycleRegisted { get; set; }
        public int? DataCapacity { get; set; }
        public decimal? MonthlyBillingAmount { get; set; }
        public decimal? SuspendFee { get; set; }
        public decimal? ActiveFee { get; set; }
        public decimal? ReActiveFee { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? ContractDueDate { get; set; }
        public DateTime? BillingStartDate { get; set; }
        public DateTime? BillingDueDate { get; set; }
        public DateTime? LastSync { get; set; }
        public string Provider { get; set; }
    }
    public enum Status
    {
        ACTIVED, SUSPEND,DEACTIVE
    }
}

