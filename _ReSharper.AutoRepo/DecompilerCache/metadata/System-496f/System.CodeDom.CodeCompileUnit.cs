// Type: System.CodeDom.CodeCompileUnit
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.dll

using System;
using System.Collections.Specialized;
using System.Runtime;
using System.Runtime.InteropServices;

namespace System.CodeDom
{
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Serializable]
    public class CodeCompileUnit : CodeObject
    {
        public CodeNamespaceCollection Namespaces { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        public StringCollection ReferencedAssemblies { get; }
        public CodeAttributeDeclarationCollection AssemblyCustomAttributes { get; }
        public CodeDirectiveCollection StartDirectives { get; }
        public CodeDirectiveCollection EndDirectives { get; }
    }
}
