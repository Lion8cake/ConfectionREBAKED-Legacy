using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using TheConfectionRebirth.Items.Banners;

namespace TheConfectionRebirth.NPCs.Meowzer
{
    public class Meowzer : ModNPC
    {
        NPC hitbox;
        bool[] cannon = new bool[3];
        float[] lockOn = new float[5];
        Vector2 oldVel;
        int lockDir;
        bool[] sight = new bool[2];
        Vector2 lastSeen;
        float[] jitter = new float[3];
        float[] recoil = new float[4];
        int[] frame = new int[2];
        int[] index = new int[2];
        Vector2[] tailSeg = new Vector2[4];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meowzer");
        }
        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 50;
            aiType = -1;
            npc.lifeMax = 280;
            npc.defense = 24;
            npc.damage = 70;
            npc.knockBackResist = 0.2f;
            npc.value = Item.buyPrice(0, 0, 7, 50);
            npc.npcSlots = 1f;
            npc.noGravity = true;
            npc.netAlways = true;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.Item2;
			banner = npc.type;
			bannerItem = ModContent.ItemType<MeowzerBanner>();
        }
        public override void AI()
        {
            if (!cannon[1])
            {
                npc.lifeMax = npc.life = 560;
                MeowzerCannonHitbox h = Main.npc[NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<MeowzerCannonHitbox>())].modNPC as MeowzerCannonHitbox;
                h.owner = npc;
                hitbox = h.npc;
                cannon[1] = true;
            }
            if ((hitbox == null || !hitbox.active) && !cannon[2])
            {
                cannon[2] = true;
                Enrage();
            }
            UCR();
            if (oldVel != Vector2.Zero)
                npc.velocity = new Vector2(MathHelper.Lerp(oldVel.X, 0, lockOn[1]), MathHelper.Lerp(oldVel.Y, 0, lockOn[1] + 0.02f));
            npc.spriteDirection = npc.velocity.X < 0 ? -1 : 1;
            npc.noTileCollide = cannon[0];
            npc.aiStyle = cannon[0] ? 2 : 22;
            npc.rotation = npc.velocity.ToRotation();
            if (!cannon[0])
                npc.rotation *= npc.direction == -1 ? -0.01f : 0.05f;
            if (!cannon[0])
            {
                if (recoil[1] > 0)
                {
                    jitter[2] = 0;
                    recoil[1]++;
                    if (recoil[1] >= 31)
                        recoil[1] = 0;
                    Recoil();
                }
                lockOn[1] = (float)Math.Sin(lockOn[4]);
                if (lockOn[3] > 0)
                {
                    lockOn[4] -= (float)Math.PI / 30;
                    if (lockOn[4] < 0)
                        Reset();
                }
                lockOn[0]++;
                if (lockOn[0] >= 240)
                {
                    if (Target() != null)
                    {
                        Player targ = Target();
                        if (Collision.CanHitLine(targ.MountedCenter, targ.width, targ.height, npc.Center, npc.width, npc.height))
                            sight[0] = true;
                        if (sight[0])
                        {
                            if (Collision.CanHitLine(targ.MountedCenter, targ.width, targ.height, npc.Center, npc.width, npc.height) && !sight[1])
                                lastSeen = targ.MountedCenter;
                            else
                                sight[1] = true;
                            if (lockDir == 0)
                                lockDir = Target().MountedCenter.X < npc.position.X ? -1 : 1;
                            npc.direction = npc.spriteDirection = lockDir;
                            if (oldVel == Vector2.Zero)
                                oldVel = npc.velocity;
                            if (lockOn[1] < 1f)
                                lockOn[4] += (float)Math.PI / 60;
                            if (lockOn[4] >= Math.PI * 0.475f)
                            {
                                Charge();
                                if (lockOn[0] >= 340)
                                    Fire();
                            }
                        }
                        else
                            lockOn[0] = 0;
                    }
                }
            }
            else
            {
                if (index[1]++ > 10)
                {
                    index[1] = 0;
                    if (index[0]++ > 2)
                        index[0] = 0;
                    tailSeg[index[0]] = npc.Center;
                }
            }
            //Update Cannon Rotation
            void Reset()
            {
                lockOn[1] = 0;
                lockOn[3] = 0;
                oldVel = Vector2.Zero;
                lockDir = 0;
                sight[0] = false;
                sight[1] = false;
                jitter[0] = 0;
                jitter[1] = 0;
            }
            void UCR()
            {
                if (Target() != null)
                {
                    float rot = (float)Math.Atan2((double)((float)lastSeen.Y - npc.Center.Y), (double)((float)lastSeen.X - npc.Center.X));
                    lockOn[2] = MathHelper.Lerp(npc.rotation + (npc.spriteDirection == 1 ? 1.5f : -1.5f), rot + 1.75f, lockOn[1]);
                }
            }
            void Charge()
            {
                float scale = lockOn[0] / 400;
                jitter[2] += 0.03f;
                if (jitter[2] > 1)
                    jitter[2] = 1;
                jitter[0] = Main.rand.NextFloat(-0.75f, 0.75f) * scale;
                jitter[1] = Main.rand.NextFloat(-0.75f, 0.75f) * scale;
                if (frame[0]++ > 15)
                {
                    frame[0] = 0;
                    if (frame[1]++ > 2)
                        frame[1] = 0;
                }
            }
            void Fire()
            {
                Vector2 val = lastSeen;
                Vector2 val2 = val - npc.Center;
                float num2 = 10f;
                float num3 = (float)Math.Sqrt(val2.X * val2.X + val2.Y * val2.Y);
                if (num3 > num2)
                    num3 = num2 / num3;
                val2 *= num3;
                recoil[2] = val2.X;
                recoil[3] = val2.Y;
                Vector2 firePos = npc.Center + new Vector2((npc.spriteDirection == -1 ? 20f : 0f), -45f);
                Projectile.NewProjectile(firePos, val2 *= 0.5f, ModContent.ProjectileType<MeowzerBeam>(), Utilities.DL(125), 2.5f);
                lockOn[3] = 1;
                lockOn[0] = 0;
                recoil[1] = 1;
                Main.PlaySound(SoundID.Item67, npc.Center);
                if (Main.rand.NextBool(4))
                    Main.PlaySound(Main.rand.NextBool(1) ? SoundID.Item57.WithPitchVariance(0.1f) : SoundID.Item58.WithPitchVariance(0.1f), npc.Center);
            }
            void Recoil()
            {
                recoil[0] += (float)Math.PI / 30;
                float sine = (float)(0.5 * Math.Cos(recoil[0]) + 0.5);
                npc.position.X += (recoil[2] * sine) * -0.25f;
                npc.position.Y += (recoil[3] * sine) * -0.25f;
            }
            void Enrage()
            {
                cannon[0] = true;
                Reset();
                Main.PlaySound(SoundLoader.customSoundType, npc.Center, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Pigron"));
            }
        }
        Player Target()
        {
            npc.TargetClosest(true);
            return Main.player[npc.target];
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (!cannon[0])
            {
                Texture2D idle = ModContent.GetTexture("TheConfectionRebirth/NPCs/Meowzer/MeowzerIdle");
                Texture2D cannon = ModContent.GetTexture("TheConfectionRebirth/NPCs/Meowzer/MeowzerCannon");
                Texture2D charge = ModContent.GetTexture("TheConfectionRebirth/NPCs/Meowzer/MeowzerCannonCharge");
                Vector2 pos = DS.DrawPos(npc.Center) + (npc.spriteDirection == 1 ? new Vector2(-15, 0) : Vector2.Zero);
                Vector2 cannonOrg = DS.DrawOrigin(cannon);
                SpriteEffects effect = DS.FlipTex(npc.spriteDirection);
                cannonOrg.X += jitter[0];
                cannonOrg.Y += jitter[1];
                spriteBatch.Draw(idle, pos + new Vector2(10, -20), DS.DrawFrame(idle), drawColor, npc.rotation, DS.DrawOrigin(idle), 1, effect, 0);
                spriteBatch.Draw(cannon, pos + new Vector2((npc.spriteDirection == -1 ? 20f : 0f), -45f), DS.DrawFrame(cannon), drawColor, lockOn[2], cannonOrg, 1, effect, 0);
                spriteBatch.Draw(charge, pos + new Vector2((npc.spriteDirection == -1 ? 20f : 0f), -45f), DS.DrawFrame(cannon, 0, cannon.Height * frame[1]), Utilities.LerpColor(Color.Transparent, drawColor, jitter[2]), lockOn[2], cannonOrg, 1, effect, 0);
            }
            else
            {
                Texture2D tex = ModContent.GetTexture("TheConfectionRebirth/NPCs/Meowzer/MeowzerTailSeg");
                Texture2D tex2 = Main.npcTexture[npc.type];
                for (int a = 0; a < tailSeg.Length; a++)
                {
                    if (tailSeg[a] != null || tailSeg[a] != Vector2.Zero)
                    {
                        Rectangle rect = new Rectangle(0, Y(), 14, 14);
                        spriteBatch.Draw(tex, tailSeg[a] - Main.screenPosition, rect, drawColor, 0, new Vector2(7), 1, DS.FlipTex(-1), 0);
                    }
                    int Y()
                    {
                        switch(a)
                        {
                            case 0:
                                return 28;
                            case 1:
                                return 14;
                            case 2:
                                return 0;
                            case 3:
                                return 14;
                        }
                        return 42;
                    }
                }
                spriteBatch.Draw(tex2, DS.DrawPos(npc.Center), DS.DrawFrame(tex2), drawColor, npc.rotation *= 0.25f, DS.DrawOrigin(tex2), npc.scale, npc.velocity.X < 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
            }
            return false;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int a = 0; a < 3; a++)
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/Meowzer/Meowzer{a}"), 1f);
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(5, 10));
            if (Main.rand.NextBool(5))
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.PastryBlock>(), Main.rand.Next(10, 15));
            if (Main.rand.NextBool(333))
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.ToastyToaster>());
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
                return spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? 0.8f : 0f;
            return 0;
        }
    }
    public class MeowzerBeam : ModProjectile
    {
        int[] alpha = new int[2];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meowzer Beam");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            aiType = ProjectileID.Bullet;
            projectile.width = 30;
            projectile.height = 42;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.coldDamage = true;
            projectile.friendly = false;
            projectile.hostile = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D beam = ModContent.GetTexture("TheConfectionRebirth/NPCs/Meowzer/MeowzerBeam");
            Texture2D tex = ModContent.GetTexture("TheConfectionRebirth/NPCs/Meowzer/MeowzerBeamPrime");
            float val = (float)alpha[1] / 255;
            Vector2 drawOrigin = new Vector2(tex.Width / 4, tex.Height / 2);
            drawOrigin.X -= 15f;
            drawOrigin.Y -= 25f;
            Rectangle refRect = new Rectangle(tex.Width / 2, 0, tex.Width / 2, tex.Height);
            Rectangle rectangle = new Rectangle(refRect.X, refRect.Y, (tex.Width / 2), (tex.Height / Main.projFrames[projectile.type]));
            spriteBatch.Draw(beam, projectile.Center - Main.screenPosition, new Rectangle(0, 0, beam.Width / 2, beam.Height), Utilities.LerpColor(Color.Transparent, lightColor, val), projectile.rotation, drawOrigin + new Vector2(15, -5), projectile.scale * 1.25f, DS.FlipTex(-1), 0f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(15f, projectile.gfxOffY - 5);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(beam, drawPos, new Rectangle(beam.Width / 2, 0, beam.Width / 2, beam.Height), Utilities.LerpColor(Color.Transparent, color, val * 0.5f), projectile.rotation, drawOrigin + new Vector2(15, 0), projectile.scale, DS.FlipTex(-1), 0f);
                spriteBatch.Draw(tex, drawPos, rectangle, color, projectile.rotation, drawOrigin + new Vector2(15, -5), projectile.scale, DS.FlipTex(-1), 0f);
            }
            return false;
        }
        public override void AI()
        {
            if (alpha[0]++ > 20)
            {
                float val = MathHelper.Lerp(0, 255, (float)alpha[1] / 255);
                alpha[1] += 5;
                if (alpha[1] > 255)
                    alpha[1] = 255;
                Lighting.AddLight(projectile.Center, new Vector3(val *= 0.015f));
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.NPCDeath3, projectile.Center);
            for (int i = 0; i < 14; i++)
            {
                Vector2 position = projectile.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 14 * i));
                Dust dust = Dust.NewDustPerfect(position, 66);
                dust.noGravity = true;
                dust.velocity = Vector2.Normalize(dust.position - projectile.Center) * 8.75f;
                dust.noLight = false;
                dust.fadeIn = 1f;
            }
        }
    }
    public class MeowzerCannonHitbox : ModNPC
    {
        public NPC owner;
        bool scaleStat;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meowzer Tail");
        }
        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 20;
            npc.aiStyle = -1;
            npc.lifeMax = 75;
            npc.defense = 16;
            npc.knockBackResist = 0f;
            npc.npcSlots = 1f;
            npc.noGravity = true;
            npc.netAlways = true;
            npc.HitSound = SoundID.NPCHit38;
            npc.DeathSound = SoundID.NPCDeath41;
        }
        public override void AI()
        {
            if (!scaleStat)
            {
                npc.lifeMax = npc.life = 150;
                scaleStat = true;
            }
            if (owner == null || !owner.active)
            {
                npc.life = int.MinValue;
                npc.checkDead();
            }
            else if (owner.modNPC is Meowzer m)
                npc.position = m.npc.Center + new Vector2(owner.spriteDirection == -1 ? 10f : -20f, -55f);
        }
        public override void NPCLoot() { Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Meowzer/MeowzerTail"), 1f); }
        public override bool CheckActive() => false;
    }
}
