// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an extension associated with virtual machine instance
    /// in a scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetVMInstanceExtension  :
        IVirtualMachineExtensionBase,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>
    {
    }
}