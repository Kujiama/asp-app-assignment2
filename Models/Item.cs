﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class AfterCurrentDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateValue = (DateTime)value;
            if (dateValue.Date <= DateTime.Now.Date)
            {
                return new ValidationResult($"Start date of bidding should be after the current date.");
            }

            return ValidationResult.Success;
        }
    }
    public class EndBidDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
         
            DateTime endDateValue = (DateTime)value;
            DateTime startDateValue = ((Item)validationContext.ObjectInstance).StartBidDate ?? DateTime.MinValue;

            if (endDateValue.Date < startDateValue.Date)
            {
                return new ValidationResult($"End date of bidding should be after the start date of bidding.");
            }

            return ValidationResult.Success;
        }
    }

    public class Item
    {
        [Key] // Primary key for Item
        public int Id { get; set; }

        [ForeignKey ("User")]
        public string? UserId { get; set; }
        [Display(Name = "Seller")]
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }


        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Please enter a valid item name")]
        [StringLength(50, ErrorMessage = "item name cannot be longer than 50 characters")]
        public string? Name { get; set; }


		[Display(Name = "Description")]
		[Required(ErrorMessage = "Please enter a valid item description")]
        [StringLength(250, ErrorMessage = "Item description cannot be longer than 250 characters")]
        public string? Description { get; set; }

		[Display(Name = "Minimum Bid")]
		[Range(1, 10000, ErrorMessage = "Please enter a minimum bid")]
        public double? MinimumBid { get; set; }

		[Display(Name = "Start Date of Bidding")]
		[Required(ErrorMessage = "Please enter start date of bidding")]
        [DataType(DataType.DateTime)]
        [AfterCurrentDate(ErrorMessage = "Start date of bidding should be after the current date")]
        public DateTime? StartBidDate { get; set; }

		[Display(Name = "End Date of Bidding")]
		[Required(ErrorMessage = "Please enter end date of bidding")]
        [DataType(DataType.DateTime)]
        [EndBidDate(ErrorMessage = "End date of bidding should be after the current and start date of bidding")]
        public DateTime? EndBidDate { get; set; }

		[Display(Name = "Item Condition")]
		[Required(ErrorMessage = "Please select a condition")]
        public string? Condition { get; set; }

		[Display(Name = "Item Category")]
		[Required(ErrorMessage = "Please select a category")]
        public string? Category { get; set; }

        [Display(Name = "Image")]
        public byte[]? ItemPicture { get; set; }
    }

}
