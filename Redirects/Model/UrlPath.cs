using System;
using System.Collections.Generic;

namespace Forte.RedirectMiddleware.Model
{
    public class UrlPath : IEquatable<UrlPath>
    {
        private const string InvalidRelativePathExceptionMessage = "Entered path is not a valid relative path.";
        public Uri Path { get; }

        public static UrlPath Create(string oldPath)
        {
            try
            {
                NormalizePath(oldPath);
                var urlPath = new UrlPath(oldPath);
                return urlPath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ArgumentException(InvalidRelativePathExceptionMessage, e);
            }

        }
        public static bool TryCreate(string oldPath, out UrlPath urlPath)
        {
            try
            {             
                urlPath = Create(oldPath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(InvalidRelativePathExceptionMessage + e);
                urlPath = null;
                return false;
            }
        }
        private UrlPath(string oldPath)
        {
            Path = new Uri(oldPath, UriKind.Relative);
        }

        private static string NormalizePath(string path)
        {
            path = path.Trim();
            path = path[0] == '/'
                ? path
                : '/' + path;

            if (path.Length > 1)
                path = path.TrimEnd('/');

            return path;
        }

        public static bool operator ==(UrlPath a, UrlPath b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(UrlPath a, UrlPath b)
        {
            return !(a == b);
        }

        private bool Equals(UrlPath other, StringComparison stringComparison)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Path.OriginalString, other.Path.OriginalString, stringComparison);
        }

        public bool Equals(UrlPath other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Path.OriginalString, other.Path.OriginalString, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((UrlPath) obj);
        }
        
        public override int GetHashCode()
        {    
            return (Path?.OriginalString != null ? Path.OriginalString.GetHashCode() : 0);
        }
    }
}