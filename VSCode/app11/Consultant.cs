using System;

namespace app11
{
    public class Consultant : User
    {
        public Consultant(string Name) : base(Name, UserRole.Consultant)
        {

        }
    }
}
