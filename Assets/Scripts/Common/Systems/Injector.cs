using System;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Architecture.Common
{
    public static class Injector
    {
        const string MonoBehaviour = "MonoBehaviour";
        const string AssemblyPrefix = "Architecture";
        public static void InjectNonMonoBehaviourConfigs()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                if (!assemblies[i].FullName.StartsWith(AssemblyPrefix))
                    continue;

                Type[] types = assemblies[i].GetTypes();
                for (int j = 0; j < types.Length; j++)
                {
                 
                    Type baseType = types[j].BaseType;

                    while (baseType != null)
                    {
                        if (baseType.Name == MonoBehaviour)
                            break;
                        baseType = baseType.BaseType;
                    }
                    if (baseType != null && baseType.Name == MonoBehaviour)
                        continue;

                    FieldInfo[] members = types[j].GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                    for (int k = 0; k < members.Length; k++)
                    {
                        if (!members[k].FieldType.Name.EndsWith("Config"))
                            continue;

                        Object[] configs = Resources.LoadAll("Configs");
                        for (int l = 0; l < configs.Length; l++)
                        {
                            if (!configs[l].GetType().Equals(members[k].FieldType))
                                continue;

                            members[k].SetValue(members[k], configs[l]);
                            break;
                        }
                    }
                }
            }
        }

        public static void InjectMonoBehaviourConfigs()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                if (!assemblies[i].FullName.StartsWith(AssemblyPrefix))
                    continue;

                Type[] types = assemblies[i].GetTypes();
                for (int j = 0; j < types.Length; j++)
                {
                    Type baseType = types[j].BaseType;

                    while (baseType != null)
                    {
                        if (baseType.Name == MonoBehaviour)
                            break;
                        baseType = baseType.BaseType;
                    }

                    if (baseType == null || baseType.Name != MonoBehaviour)
                        continue;

                    FieldInfo[] members = types[j].GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                    for (int k = 0; k < members.Length; k++)
                    {
                        if (!members[k].FieldType.Name.EndsWith("Config"))
                            continue;

                        Object[] configs = Resources.LoadAll("Configs");
                        for (int l = 0; l < configs.Length; l++)
                        {
                            if (!configs[l].GetType().Equals(members[k].FieldType))
                                continue;

                            Object referencedObject = Object.FindFirstObjectByType(types[j]);
                            if (referencedObject != null)
                                members[k].SetValue(referencedObject, configs[l]);

                            break;
                        }
                    }
                }
            }
        }
    }
}