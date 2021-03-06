﻿using MVCUdemy1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCUdemy1.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedNewSettler { get; set; }
         public byte MembershipTypeId { get; set; }
         public DateTime? BirthDate { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }

    }
}