using System.Collections.Generic;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Method
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
        public IEncodable Parameters { get; set; }

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
        {
            ModuleIndex = moduleIndex;
            CallIndex = callIndex;
            ParametersBytes = parameters ?? new byte[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        /// <param name="moduleIndex">Index of the module.</param>
        /// <param name="callIndex">Index of the call.</param>
        public Method(byte moduleIndex, byte callIndex)
        {
            ModuleIndex = moduleIndex;
            CallIndex = callIndex;
            ParametersBytes = new byte[0];
        }

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
            ParametersBytes = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        /// <param name="moduleIndex"></param>
        /// <param name="moduleName"></param>
        /// <param name="callIndex"></param>
        /// <param name="callName"></param>
        /// <param name="parameters"></param>
        public Method(byte moduleIndex, string moduleName, byte callIndex, string callName, IEncodable parameters) 
            : this(moduleIndex, moduleName, callIndex, callName, parameters.Encode())
        { }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            var result = new List<byte>();
            result.Add(ModuleIndex);
            result.Add(CallIndex);
            result.AddRange(ParametersBytes);
            return result.ToArray();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}