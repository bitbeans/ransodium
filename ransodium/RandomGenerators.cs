using System;
using System.Security.Cryptography;

namespace ransodium
{
    /// <summary>
    ///     Getting random numbers in a thread-safe way.
    /// </summary>
    /// <see cref="http://blogs.msdn.com/b/pfxteam/archive/2009/02/19/9434171.aspx" />
    public static class FastRandomGenerator
    {
        private static readonly Random Global = new Random();

        [ThreadStatic] private static Random _local;

        /// <summary>
        ///     Gets a random integer.
        /// </summary>
        /// <returns>A random integer.</returns>
        public static int Next()
        {
            var inst = _local;
            if (inst == null)
            {
                int seed;
                lock (Global) seed = Global.Next();
                _local = inst = new Random(seed);
            }
            return inst.Next();
        }
    }

    /// <summary>
    ///     Getting secure random numbers in a thread-safe way.
    /// </summary>
    /// <see cref="http://blogs.msdn.com/b/pfxteam/archive/2009/02/19/9434171.aspx" />
    public static class SecureRandomGenerator
    {
        private static readonly RNGCryptoServiceProvider Global =
            new RNGCryptoServiceProvider();

        [ThreadStatic] private static Random _local;

        /// <summary>
        ///     Gets a cryptographic secure random integer.
        /// </summary>
        /// <returns>A cryptographic secure random integer.</returns>
        /// <exception cref="CryptographicException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static int Next()
        {
            var inst = _local;
            if (inst == null)
            {
                var buffer = new byte[4];
                Global.GetBytes(buffer);
                _local = inst = new Random(
                    BitConverter.ToInt32(buffer, 0));
            }
            return inst.Next();
        }
    }
}