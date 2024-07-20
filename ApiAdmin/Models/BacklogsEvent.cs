﻿using System;
using System.Collections.Generic;

namespace ApiAdmin.Models;

public partial class BacklogsEvent
{
    public int Id { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? CompleteAt { get; set; }

    public int EventType { get; set; }

    public string Json { get; set; }
}
