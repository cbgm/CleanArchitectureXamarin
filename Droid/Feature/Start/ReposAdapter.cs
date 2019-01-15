using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CleanArch.Droid.Model;
using static Android.Support.V7.Widget.RecyclerView;

namespace CleanArch.Droid.Feature.Start
{
    public class ReposAdapter : RecyclerView.Adapter
    {
        private List<RepoOrganizationEntity> ItemsList = new List<RepoOrganizationEntity>();

        public override int ItemCount => ItemsList.Count;
       

        public void addItems(List<RepoOrganizationEntity> items)
        {
            ItemsList.AddRange(items);
            NotifyDataSetChanged();
        }

        public override int GetItemViewType(int position)
        {
            return Resource.Layout.item_repo;
        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == Resource.Layout.item_repo)
            {
                var inflater = LayoutInflater.From(parent.Context);
                return new RepoViewHolder(inflater.Inflate(viewType, parent, false));
            }

            throw new InvalidOperationException("This type of layout is not supported");
        }

        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            if (holder is RepoViewHolder)
            {
                ((RepoViewHolder)holder).bindData(ItemsList[position]);
            }
        }

        public class RepoViewHolder : ViewHolder
        {
            private TextView tvOrg;
            private TextView tvRepo;
            private TextView tvDescr;
            private TextView tvLang;

            public RepoViewHolder(View itemView) : base(itemView)
            {
                tvOrg = itemView.FindViewById(Resource.Id.tv_org) as TextView;
                tvRepo = itemView.FindViewById(Resource.Id.tv_repo) as TextView;
                tvDescr = itemView.FindViewById(Resource.Id.tv_description) as TextView;
                tvLang = itemView.FindViewById(Resource.Id.tv_language) as TextView;

            }

            public void bindData(RepoOrganizationEntity data)
            {
                tvOrg.Text = data.owner.login;
                tvRepo.Text = data.name;
                tvDescr.Text = data.description;
                tvLang.Text = data.language;
            }
        }
    }
}