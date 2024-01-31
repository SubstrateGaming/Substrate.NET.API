using System.Collections.Generic;
using System.Linq;
using Substrate.NetApi.Model.Types;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Represents a method call in a blockchain transaction, encapsulating module and call information along with parameters.
    /// </summary>
    public class Method
    {
        /// <summary>
        /// Module Name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Module Index
        /// </summary>
        public byte ModuleIndex { get; set; }

        /// <summary>
        /// Call Name
        /// </summary>
        public string CallName { get; set; }

        /// <summary>
        /// Call Index
        /// </summary>
        public byte CallIndex { get; set; }

        /// <summary>
        /// Parameters unencoded
        /// </summary>
        public IType[] Parameters { get; set; }

        /// <summary>
        /// Parameters
        /// </summary>
        public byte[] ParametersBytes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        /// <param name="moduleIndex">Index of the module.</param>
        /// <param name="callIndex">Index of the call.</param>
        /// <param name="parameters">The parameters.</param>
        public Method(byte moduleIndex, byte callIndex, byte[] parameters) 
            : this(moduleIndex, null, callIndex, null, parameters)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        /// <param name="moduleIndex">Index of the module.</param>
        /// <param name="callIndex">Index of the call.</param>
        public Method(byte moduleIndex, byte callIndex)
            : this(moduleIndex, callIndex, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        /// <param name="moduleIndex">Index of the module.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="callIndex">Index of the call.</param>
        /// <param name="callName">Name of the call.</param>
        /// <param name="parameters">The parameters.</param>
        public Method(byte moduleIndex, string moduleName, byte callIndex, string callName, byte[] parameters)
        {
            ModuleName = moduleName;
            ModuleIndex = moduleIndex;
            CallName = callName;
            CallIndex = callIndex;
            Parameters = null;
            ParametersBytes = parameters ?? new byte[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        /// <param name="moduleIndex">Index of the module.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="callIndex">Index of the call.</param>
        /// <param name="callName">Name of the call.</param>
        /// <param name="iTypes">The ITypes array.</param>
        public Method(byte moduleIndex, string moduleName, byte callIndex, string callName, IType[] iTypes)
        {
            ModuleName = moduleName;
            ModuleIndex = moduleIndex;
            CallName = callName;
            CallIndex = callIndex;
            Parameters = iTypes;
            ParametersBytes = iTypes.SelectMany(param => param.Encode()).ToArray();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            var result = new List<byte>
            {
                ModuleIndex,
                CallIndex
            };
            result.AddRange(ParametersBytes);
            return result.ToArray();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Module: {ModuleName}, Call: {CallName}, Indexes: [{ModuleIndex}, {CallIndex}]";
        }
    }
}