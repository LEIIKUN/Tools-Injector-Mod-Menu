﻿using System.Collections.Generic;
using System.Linq;

namespace Tools_Injector_Mod_Menu.Patch_Manager
{
    public static class OffsetPatch
    {
        public static List<OffsetInfo> OffsetList = new List<OffsetInfo>();
        public static List<FunctionList> FunctionList = new List<FunctionList>();
        public static TFiveMenu T5Menu = new TFiveMenu();

        public static void AddOffset(OffsetInfo offsetInfo)
        {
            OffsetList.Add(offsetInfo);
        }

        public static void AddOffset(OffsetInfo offsetInfo, List<OffsetInfo> offsetList)
        {
            offsetList.Add(offsetInfo);
        }

        public static void AddFunction(string cheatName, Enums.FunctionType functionType, string functionValue)
        {
            FunctionList.Add(new FunctionList
            {
                CheatName = cheatName,
                OffsetList = OffsetList.ToList(),
                FunctionType = functionType,
                FunctionValue = functionValue
            });
        }

        public static void AddFunction(string cheatName = null, List<OffsetInfo> offsetList = null, Enums.FunctionType functionType = Enums.FunctionType.Category, string functionValue = null, bool multipleValue = false, HookInfo hookInfo = null)
        {
            FunctionList.Add(new FunctionList
            {
                CheatName = cheatName,
                OffsetList = (offsetList ?? new List<OffsetInfo>()).ToList(),
                FunctionType = functionType,
                FunctionValue = functionValue,
                MultipleValue = multipleValue,
                HookInfo = hookInfo
            });
        }

        public static void AddFunction(string cheatName, List<OffsetInfo> offsetList, List<FunctionList> functionList)
        {
            functionList.Add(new FunctionList { CheatName = cheatName, OffsetList = offsetList });
        }

        public static List<string> ConvertNameList(List<FunctionList> functionList)
        {
            var cheatName = new List<string>();
            foreach (var result in functionList)
            {
                cheatName.Add(result.CheatName);
            }
            return cheatName;
        }

        public static List<string> ConvertNameList()
        {
            return FunctionList.Select(result => result.CheatName).ToList();
        }

        public static List<OffsetInfo> ConvertFunction(FunctionList functionList)
        {
            return functionList.OffsetList.ToList();
        }

        public static List<OffsetInfo> ConvertFunctionList(List<FunctionList> functionList)
        {
            var offsetList = new List<OffsetInfo>();
            foreach (var result in functionList)
            {
                offsetList.AddRange(result.OffsetList);
            }
            return offsetList;
        }

        public static List<OffsetInfo> ConvertFunctionList()
        {
            var offsetList = new List<OffsetInfo>();
            foreach (var result in FunctionList)
            {
                offsetList.AddRange(result.OffsetList);
            }
            return offsetList;
        }

        public static List<OffsetInfo> ConvertFunctionList(int id)
        {
            var offsetList = new List<OffsetInfo>();
            offsetList.AddRange(FunctionList[id].OffsetList);
            return offsetList;
        }
    }
}