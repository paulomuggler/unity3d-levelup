/// Copyright (C) 2012-2014 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using UnityEngine;
using System;

namespace Soomla.Levelup
{
#if UNITY_ANDROID && !UNITY_EDITOR
	
	override protected void _setCompleted(Mission mission, boolean completed, boolean notify) {
		AndroidJNI.PushLocalFrame(100);
		using(AndroidJavaClass jniMissionStorage = new AndroidJavaClass("com.soomla.levelup.data.MissionStorage")) {
			jniMissionStorage.CallStatic("setCompleted", mission.toJNIObject(), completed, notify);
		}
		AndroidJNI.PopLocalFrame(IntPtr.Zero);
	}
	
	override protected bool _isCompleted(Mission mission) {
		bool completed = false;
		AndroidJNI.PushLocalFrame(100);
		using(AndroidJavaClass jniMissionStorage = new AndroidJavaClass("com.soomla.levelup.data.MissionStorage")) {
			given = jniMissionStorage.CallStatic<bool>("isCompleted", mission.toJNIObject());
		}
		AndroidJNI.PopLocalFrame(IntPtr.Zero);
		return completed;
	}
	
#endif
}

