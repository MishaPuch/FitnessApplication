using System;
using System.Collections.Generic;

namespace EmailVereficationMicroservice.Model;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public int Age { get; set; }

    public int RestTime { get; set; }

    public int CalorificValue { get; set; }

    public DateTime DateOflastPayment { get; set; }

    public int TreningPlanId { get; set; }

    public int RoleId { get; set; }

    public string? Avatar { get; set; }

    public bool? IsEmailConfirmed { get; set; }

}
