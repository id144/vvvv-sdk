﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    public class LeaveOpenStreamWriter : StreamWriter
    {
        public LeaveOpenStreamWriter(Stream stream)
            : base(stream)
        {
        }

        protected override void Dispose(bool disposing)
        {
            // Workaround to leave the underlying stream open.
            // .NET 4.5 fixes this with new leaveOpen parameter on constructor.
            Flush();
            base.Dispose(false);
        }
    }
}
