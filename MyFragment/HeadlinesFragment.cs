﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MyFragment
{
    public class HeadlinesFragment : ListFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnActivityCreated(savedInstanceState);
            var adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, FinancialNews.Headlines);
            ListAdapter = adapter;

        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowNewsStory(position);
            Console.WriteLine("ShowNewsStory(position):" + position);
        }

        public void ShowNewsStory(int headlineID)
        {
            ListView.SetItemChecked(headlineID, true);
            var story = FragmentManager.FindFragmentById(Resource.Id.storyPlaceHolderID);
            story = StoryFragment.NewInstance(headlineID);
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.storyPlaceHolderID, story);
            ft.SetTransition(FragmentTransit.FragmentFade);
            ft.Commit();
        }
    }
}