using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace PirateShipCollection.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Ship : IEquatable<Ship>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>

        [DataMember(Name="category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Length
        /// </summary>

        [DataMember(Name="length")]
        public int? Length { get; set; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>

        [DataMember(Name="width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>

        [DataMember(Name="height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or Sets Weight
        /// </summary>

        [DataMember(Name="weight")]
        public int? Weight { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Ship {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Ship)obj);
        }

        /// <summary>
        /// Returns true if Ship instances are equal
        /// </summary>
        /// <param name="other">Instance of Ship to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ship other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Category == other.Category ||
                    Category != null &&
                    Category.Equals(other.Category)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Length == other.Length ||
                    Length != null &&
                    Length.Equals(other.Length)
                ) && 
                (
                    Width == other.Width ||
                    Width != null &&
                    Width.Equals(other.Width)
                ) && 
                (
                    Height == other.Height ||
                    Height != null &&
                    Height.Equals(other.Height)
                ) && 
                (
                    Weight == other.Weight ||
                    Weight != null &&
                    Weight.Equals(other.Weight)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Category != null)
                    hashCode = hashCode * 59 + Category.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Length != null)
                    hashCode = hashCode * 59 + Length.GetHashCode();
                    if (Width != null)
                    hashCode = hashCode * 59 + Width.GetHashCode();
                    if (Height != null)
                    hashCode = hashCode * 59 + Height.GetHashCode();
                    if (Weight != null)
                    hashCode = hashCode * 59 + Weight.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Ship left, Ship right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Ship left, Ship right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
