using System;
using System.Collections.Generic;

namespace EmailVereficationMicroservice.Model;

public partial class VereficationUser
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int VereficationCode { get; set; }
}
