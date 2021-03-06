using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class GreaterExplosionPotion : BaseExplosionPotion
	{
		public override int MinDamage { get { return 20; } }
		public override int MaxDamage { get { return 40; } }

		[Constructable]
		public GreaterExplosionPotion() : base( PotionEffect.ExplosionGreater )
		{
		}

		public GreaterExplosionPotion( Serial serial ) : base( serial )
		{
		}

        public override void OnSingleClick(Mobile from)
        {
            if (this.Name != null)
            {
                from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", this.Name));
            }
            else
            {
                from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", "a Greater Explosion potion"));
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}