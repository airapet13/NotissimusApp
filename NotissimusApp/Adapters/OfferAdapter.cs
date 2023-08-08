using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;



namespace NotissimusApp
{
    internal class OfferAdapter : RecyclerView.Adapter
    {
        private List<Offer> _offersList;

        public OfferAdapter(List<Offer> offersList)
        {
            _offersList = offersList;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_item, parent, false);
            return new OfferViewHolder(itemView);
        }

        public event EventHandler<Offer> ItemClick;
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is OfferViewHolder offerViewHolder)
            {
                Offer offer = _offersList[position];
                offerViewHolder.TextViewOfferId.Text = offer.Id;
            }

            holder.ItemView.Click += (sender, e) =>
            {
                ItemClick?.Invoke(this, _offersList[position]);
            };

        }

        public void UpdateData(List<Offer> offers)
        {
            _offersList = offers;
            NotifyDataSetChanged();
        }

        public override int ItemCount => _offersList.Count;

        private class OfferViewHolder : RecyclerView.ViewHolder
        {
            public TextView TextViewOfferId { get; private set; }

            public OfferViewHolder(View itemView) : base(itemView)
            {
                TextViewOfferId = itemView.FindViewById<TextView>(Resource.Id.textViewOfferId);
            }
        }
    }
}