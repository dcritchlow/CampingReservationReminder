using System;

namespace EventQueryService.DTO
{
    public class Camper : IEquatable<Camper>
    {
        public string Name { get; }

        public Camper(string camperName)
        {

            Name = camperName;
        }

        public bool Equals(Camper other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Camper && Equals((Camper)obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(Camper a, Camper b) =>
            (a is null && b is null) ||
            (!(a is null) && a.Equals(b));

        public static bool operator !=(Camper a, Camper b) =>
            !(a == b);
    }
}
