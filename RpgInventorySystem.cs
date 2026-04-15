using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day14_1_RPG
{
    interface Monster
    {
        string Name { get; }
        int Hp { get; set; }
        int Att { get; }
        int[] Loot { get; }

        void Attack(Player player);

    }
    public class Player
    {
        public string Name { get; set; }
        int hp = 2000;
        int maxhp = 2000;
        int mp = 40;
        int maxmp = 40;
        int att = 200;
        int gold = 0;
        int level = 1;
        int exp = 0;
        int[] inventory = new int[50];
        int[] equipmentInventory = new int[] { 9999, 9999, 9999 };
        int potioncount;
        int emptycount = 0;
        bool isinvenempty = true;
        bool isinvenfull = false;

        public int HP
        {
            get { return hp; }
            set { hp = value; if (hp < 0) hp = 0; }
        }
        public int MaxHP
        {
            get { return maxhp; }
            set { maxhp = value; if (hp > maxhp) hp = maxhp; } // (의도 유지)
        }
        public int MP
        {
            get { return mp; }
            set { mp = value; if (mp < 0) mp = 0; }
        }
        public int MaxMP
        {
            get { return maxmp; }
            set { maxmp = value; if (mp > MaxMP) mp = MaxMP; } // (의도 유지)
        }
        public int Att
        {
            get { return att; }
            set { att = value; }
        }
        public int Gold
        {
            get { return gold; }
            set { gold = value; if (gold < 0) gold = 0; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Exp
        {
            get { return exp; }
            set
            {
                exp = value;
                if (exp >= 100)
                {
                    Level++; exp -= 100;
                    Console.WriteLine("★☆★☆★☆레벨업!!★☆★☆★☆");
                    Att += 10;
                    MaxHP += 200;
                    HP = MaxHP;
                    MaxMP += 20;
                    MP = MaxMP;
                    Gold += 1000;
                }
            }
        }

        public int[] Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        public int[] EquipmentInventory
        {
            get { return equipmentInventory; }
            set { equipmentInventory = value; }
        }
        public int PotionCount
        {
            get { return potioncount; }
            set { potioncount = value; if (potioncount < 0) potioncount = 0; }
        }
        public int EmptyCount
        {
            get { return emptycount; }
            set
            {
                emptycount = value;
                if (emptycount >= 50) emptycount = 50; // 상한 고정
                if (emptycount < 0) emptycount = 0;    // 하한 고정
            }
        }
        public bool IsInvenEmpty
        {
            get { return isinvenempty; }
            set { isinvenempty = value; }
        }
        public bool IsInvenFull
        {
            get { return isinvenfull; }
            set { isinvenfull = value; }
        }
        public Player()
        {
            for (int i = 0; i < inventory.Length; i++) { inventory[i] = 9999; }
            // 실제 비어있는 칸 수와 EmptyCount를 동기화
            EmptyCount = inventory.Length; // 50
            IsInvenEmpty = true;
            IsInvenFull = false;
        }

        public void InputName()
        {
            Console.Write("당신의 이름은?: ");
            string name = Console.ReadLine();
            Name = name;
        }

        public void Attack(Slime slime, Goblin goblin, int monstertype)
        {

            if (monstertype == 1)
            {
                Console.WriteLine($"기본 공격을 합니다!");
                Thread.Sleep(1500);
                Console.WriteLine($"슬라임이 {Att}의 피해를 입었습니다!");
                slime.Hp -= Att;

                Console.WriteLine($"슬라임의 남은 체력: {slime.Hp}");
                Thread.Sleep(1000);
                Console.WriteLine("---------------");

            }
            else if (monstertype == 2)
            {
                Console.WriteLine($"기본 공격을 합니다!");
                Thread.Sleep(1500);
                Console.WriteLine($"고블린이 {Att}의 피해를 입었습니다!");
                goblin.Hp -= Att;

                Console.WriteLine($"고블린의 남은 체력: {goblin.Hp}");
                Thread.Sleep(1000);
                Console.WriteLine("---------------");

            }
        }
        public void UseSkill(Slime slime, Goblin goblin, int monstertype)
        {
            if (MP < 20)
            {
                Console.WriteLine("스킬을 사용할 마나가 부족합니다.");
                return;
            }

            Thread.Sleep(500);
            if (monstertype == 1)
            {
                if (EquipmentInventory[0] == 9999)
                {
                    Console.WriteLine("무기를 장착하지 않아 스킬 사용이 불가능합니다!");
                    Console.WriteLine("---------------");
                    return;
                }
                else if (EquipmentInventory[0] == 0)
                {
                    Console.WriteLine("5연속 베기!");
                    Thread.Sleep(1000);
                    Console.WriteLine($"슬라임이 {Att * 3}의 피해를 입었습니다!");
                    slime.Hp -= Att * 3;
                    Thread.Sleep(100);
                    MP -= 20;
                    return;
                }
                else if (EquipmentInventory[0] == 1)
                {
                    Console.WriteLine("5연속 내려찍기!");
                    Thread.Sleep(1000);

                    Console.WriteLine($"슬라임이 {Att * 3}의 피해를 입었습니다!");
                    Console.WriteLine("---------------");
                    slime.Hp -= Att * 3;
                    Thread.Sleep(1000);
                    MP -= 20;
                    return;
                }
                else if (EquipmentInventory[0] == 2)
                {
                    Console.WriteLine("5연속 내려치기!");
                    Thread.Sleep(1000);

                    Console.WriteLine($"슬라임이 {Att * 3}의 피해를 입었습니다!");
                    Console.WriteLine("---------------");
                    slime.Hp -= Att * 3;
                    Thread.Sleep(1000);
                    MP -= 20;
                    return;
                }

            }
            else if (monstertype == 2)
            {
                if (EquipmentInventory[0] == 9999)
                {
                    Console.WriteLine("무기를 장착하지 않아 스킬 사용이 불가능합니다!");
                    Console.WriteLine("---------------");
                    return;
                }
                else if (EquipmentInventory[0] == 0)
                {
                    Console.WriteLine("5연속 베기!");
                    Thread.Sleep(1000);

                    Console.WriteLine($"고블린이 {Att * 3}의 피해를 입었습니다!");
                    Console.WriteLine("---------------");
                    goblin.Hp -= Att * 3;
                    Thread.Sleep(1000);
                    MP -= 20;
                    return;
                }
                else if (EquipmentInventory[0] == 1)
                {
                    Console.WriteLine("5연속 내려찍기!");
                    Thread.Sleep(1000);

                    Console.WriteLine($"고블린이 {Att * 3}의 피해를 입었습니다!");
                    Console.WriteLine("---------------");
                    goblin.Hp -= Att * 3;
                    Thread.Sleep(1000);
                    MP -= 20;
                    return;
                }
                else if (EquipmentInventory[0] == 2)
                {
                    Console.WriteLine("5연속 내려치기!");
                    Thread.Sleep(1000);

                    Console.WriteLine($"고블린이 {Att * 3}의 피해를 입었습니다!");
                    Console.WriteLine("---------------");
                    goblin.Hp -= Att * 3;
                    Thread.Sleep(1000);
                    MP -= 20;
                    return;
                }

            }

        }
        public void UsePotion()
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (PotionCount == 0)
                {
                    Console.WriteLine("사용 가능한 엘릭서가 없습니다!");
                    if (Inventory[i] == 5)
                    {
                        Inventory[i] = 9999;
                    }
                    return;
                }
                else if (PotionCount >= 1)
                {
                    if (Inventory[i] == 5)
                    {
                        PotionCount--;
                        HP += 100;
                        MP += 20;
                        Console.WriteLine("체력과 마나가 회복 되었습니다!");
                        return;
                    }
                    else continue;
                }

            }
        }

        public void GetGold()
        {
            Random rand = new Random();
            int getgold = rand.Next(500, 1001);
            Gold += getgold;
            Console.WriteLine($"{getgold}원 획득!");
        }
        public void GetItem(int loot)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == 9999)
                {
                    Inventory[i] = loot;
                    EmptyCount--;
                    CheckInven(); // 동기화
                    return;
                }
            }
        }
        public void LoseGold()
        {
            Random rand = new Random();
            int losegold = rand.Next(500, 1101);

            Gold -= losegold; // 실제 차감 추가
            Console.WriteLine($"몬스터와의 전투에서 패배하여 {losegold}만큼의 골드를 잃어버렸습니다...");
            Console.WriteLine($"소유 금액: {Gold}");

        }

        public void Battle(Slime slime, Goblin goblin, int monstertype)
        {
            if (monstertype == 1) Console.WriteLine("이번 몬스터: 슬라임");
            else if (monstertype == 2) Console.WriteLine("이번 몬스터: 고블린");

            while (HP > 0 && ((monstertype == 1 && slime.Hp > 0) || (monstertype == 2 && goblin.Hp > 0)))
            {
                int beforemp = MP;
                if (monstertype == 1)
                {
                    if (slime.IsTurn == false)
                    {
                        Console.Write("무엇을 하시겠습니까? (1)기본 공격 (2)스킬 사용 (3)포션 사용: ");
                        int battleaction = int.Parse(Console.ReadLine());

                        if (battleaction == 1)
                        {
                            Attack(slime, goblin, monstertype);
                            slime.IsTurn = true;
                        }
                        else if (battleaction == 2)
                        {
                            UseSkill(slime, goblin, monstertype);
                            if (MP < beforemp)
                            {
                                slime.IsTurn = true;
                            }
                        }
                        else if (battleaction == 3)
                        {
                            UsePotion();
                            slime.IsTurn = false;
                        }
                    }
                    else if (slime.IsTurn == true)
                    {
                        slime.Attack(this);
                        slime.IsTurn = false;
                    }

                    if (HP <= 0)
                    {
                        slime.IsTurn = false;
                        Console.WriteLine($"{Name}의 패배입니다..");
                        LoseGold();
                        return;
                    }
                    else if (slime.Hp <= 0)
                    {
                        Random rand = new Random();
                        Console.WriteLine($"슬라임을 물리쳤습니다!");

                        int slloot = rand.Next(20, 23);
                        int exp = rand.Next(30, 61);
                        Console.WriteLine($"{exp}의 경험치를 획득하였습니다!");
                        Exp += exp;
                        if (slloot == 20)
                        {
                            Console.WriteLine("슬라임의 점액을 획득하였습니다!");
                            GetItem(slloot);
                            IsInvenEmpty = false;
                            GetGold();
                            Thread.Sleep(1000);
                            return;
                        }
                        else if (slloot == 21)
                        {
                            Console.WriteLine("슬라임의 정수을 획득하였습니다!");
                            GetItem(slloot);
                            IsInvenEmpty = false;
                            GetGold();
                            Thread.Sleep(1000);
                            return;

                        }
                        else if (slloot == 22)
                        {
                            Console.WriteLine("슬라임의 방울 획득하였습니다!");
                            GetItem(slloot);
                            IsInvenEmpty = false;
                            GetGold();
                            Thread.Sleep(1000);
                            return;

                        }
                    }
                }
                else if (monstertype == 2)
                {
                    if (goblin.IsTurn == false)
                    {
                        Console.Write("무엇을 하시겠습니까? (1)기본 공격 (2)스킬 사용 (3)포션 사용: ");
                        int battleaction = int.Parse(Console.ReadLine());

                        if (battleaction == 1)
                        {
                            Attack(slime, goblin, monstertype);
                            goblin.IsTurn = true;
                        }
                        else if (battleaction == 2)
                        {
                            UseSkill(slime, goblin, monstertype);
                            if (MP < beforemp)
                            {
                                goblin.IsTurn = true;
                            }
                        }
                        else if (battleaction == 3)
                        {
                            UsePotion();
                            goblin.IsTurn = false;
                        }
                    }
                    else if (goblin.IsTurn == true)
                    {
                        goblin.Attack(this);
                        goblin.IsTurn = false;
                    }

                    if (HP <= 0)
                    {
                        Console.WriteLine($"{Name}의 패배입니다..");
                        LoseGold();
                        return;
                    }
                    if (goblin.Hp <= 0)
                    {
                        Random rand = new Random();
                        Console.WriteLine($"고블린을 물리쳤습니다!");

                        int goloot = rand.Next(23, 26);
                        int exp = rand.Next(1, 61);
                        Console.WriteLine($"{exp}의 경험치를 획득하였습니다!");
                        Exp += exp;

                        if (goloot == 23)
                        {
                            Console.WriteLine("고블린의 옷자락을 획득하였습니다!");
                            GetItem(goloot);
                            IsInvenEmpty = false;
                            GetGold();
                            Thread.Sleep(1000);
                            return;
                        }
                        else if (goloot == 24)
                        {
                            Console.WriteLine("고블린의 손톱을 획득하였습니다!");
                            GetItem(goloot);
                            IsInvenEmpty = false;
                            GetGold();
                            Thread.Sleep(1000);
                            return;

                        }
                        else if (goloot == 25)
                        {
                            Console.WriteLine("고블린 고기를 획득하였습니다!");
                            GetItem(goloot);
                            IsInvenEmpty = false;
                            GetGold();
                            Thread.Sleep(1000);
                            return;

                        }
                    }

                }
            }

        }

        public void ResetMonster(Slime slime, Goblin goblin, int monstertype)
        {
            if (monstertype == 1)
            {
                slime.Hp = 2800;
                slime.IsTurn = false;
            }
            else if (monstertype == 2)
            {
                goblin.Hp = 200;
                goblin.IsTurn = false;
            }
        }

        public void PrintMyStat()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"체력: {HP}");
            Console.WriteLine($"공격력: {Att}");
            Console.WriteLine($"소지 금액: {Gold}");
            Console.WriteLine($"레벨: {Level}");

        }
        public void PrintMyInven()
        {
            Console.WriteLine("========인벤토리========");
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == 0) Console.Write($"{i}:대검 ");
                else if (inventory[i] == 1) Console.Write($"{i}:도끼 ");
                else if (inventory[i] == 2) Console.Write($"{i}:망치 ");
                else if (inventory[i] == 3) Console.Write($"{i}:갑옷 ");
                else if (inventory[i] == 4) Console.Write($"{i}:목걸이 ");
                else if (inventory[i] == 5) Console.Write($"{i}:엘릭서 10개 ");
                //20:슬라임의 점액 21:슬라임의 정수 22:슬라임의 방울
                else if (inventory[i] == 20) Console.Write($"{i}:슬라임의 점액 ");
                else if (inventory[i] == 21) Console.Write($"{i}:슬라임의 정수 ");
                else if (inventory[i] == 22) Console.Write($"{i}:슬라임의 방울 ");
                //23:고블린의 옷자락 24:고블린의 손톱 25:고블린 고기
                else if (inventory[i] == 23) Console.Write($"{i}:고블린의 옷자락 ");
                else if (inventory[i] == 24) Console.Write($"{i}:고블린의 손톱 ");
                else if (inventory[i] == 25) Console.Write($"{i}:고블린 고기 ");
                else if (inventory[i] == 9999) Console.Write("");
            }
            CheckInven();
            if (IsInvenEmpty == true) Console.WriteLine("비어있음");
        }
        public void CheckInven()
        {
            // 실제 배열을 기반으로 EmptyCount/플래그 재계산 (불일치 자동 치유)
            int empty = 0;
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == 9999) empty++;
            }
            EmptyCount = empty;
            if (EmptyCount == Inventory.Length) IsInvenEmpty = true;
            else IsInvenEmpty = false;
            if (EmptyCount == 0) IsInvenFull = true;
            else IsInvenFull = false;
        }
        public void InitializeInventory()
        {

            for (int i = 0; i < Inventory.Length; i++)
            {
                Inventory[i] = 9999;
            }
            // 초기화 시 동기화
            EmptyCount = Inventory.Length;
            IsInvenEmpty = true;
            IsInvenFull = false;
        }
        public void EquipItem()
        {
            if (IsInvenEmpty == true)
            {
                Console.WriteLine("장착할 수 있는 아이템이 없습니다!");
                return;
            }
            PrintMyInven();
            Console.Write("어떤 것을 장착할까요?: ");
            int equip = int.Parse(Console.ReadLine());
            if (Inventory[equip] == 0)
            {
                Att += 13;
                Inventory[equip] = EquipmentInventory[0];
                EquipmentInventory[0] = 0;
                // 인벤 슬롯이 9999가 되었을 때만 빈칸 증가
                if (Inventory[equip] == 9999) EmptyCount++;
                Console.WriteLine("장착 완료! 공격력이 13 증가했습니다!");
                Console.WriteLine($"현재 공격력: {Att}");
            }
            else if (Inventory[equip] == 1)
            {
                Att += 10;
                Inventory[equip] = EquipmentInventory[0];
                EquipmentInventory[0] = 1;
                if (Inventory[equip] == 9999) EmptyCount++;
                Console.WriteLine("장착 완료! 공격력이 10 증가했습니다!");
                Console.WriteLine($"현재 공격력: {Att}");
            }
            else if (Inventory[equip] == 2)
            {
                Att += 12;
                Inventory[equip] = EquipmentInventory[0];
                EquipmentInventory[0] = 2;
                if (Inventory[equip] == 9999) EmptyCount++;
                Console.WriteLine("장착 완료! 공격력이 12 증가했습니다!"); // 문구 수정
                Console.WriteLine($"현재 공격력: {Att}");
            }
            else if (Inventory[equip] == 3)
            {
                MaxHP += 200;
                Inventory[equip] = EquipmentInventory[1];
                EquipmentInventory[1] = 3;
                if (Inventory[equip] == 9999) EmptyCount++;
                Console.WriteLine("장착 완료! 최대 체력이 200 증가하였습니다!");
                Console.WriteLine($"현재 최대 체력: {MaxHP}"); // 하드코딩 제거
            }
            else if (Inventory[equip] == 4)
            {
                Att += 3;
                Inventory[equip] = EquipmentInventory[2];
                EquipmentInventory[2] = 4;
                if (Inventory[equip] == 9999) EmptyCount++;
                Console.WriteLine("장착 완료! 공격력이 3 증가하였습니다!");
                Console.WriteLine($"현재 공격력: {Att}");

            }
            else
            {
                Console.WriteLine("장착할 수 없는 아이템입니다.");
            }
            // 장착 후 상태 재계산
            CheckInven();
        }

    }

    public class Slime : Monster
    {
        string name = "슬라임";
        public string Name { get { return name; } }

        int hp = 400;
        int att = 100;
        public bool IsTurn { get; set; } = false;

        int[] loot;

        public int Hp
        {
            get { return hp; }
            set { hp = value; if (hp < 0) hp = 0; }
        }
        public int Att
        {
            get { return att; }
        }
        public int[] Loot
        {
            get { return loot; }
            //20:슬라임의 점액 21:슬라임의 정수 22:슬라임의 방울
            set { loot = new int[] { 20, 21, 22 }; }
        }

        public void Attack(Player player)
        {
            player.HP -= Att;

            Console.WriteLine($"{Name}의 공격!");
            Thread.Sleep(1500);

            Console.WriteLine($"{player.Name}은/는 {Att}의 피해를 입었습니다!");
            Console.WriteLine($"나의 남은 체력: {player.HP}");
            Console.WriteLine("---------------");
            Thread.Sleep(1000);
        }

    }

    public class Goblin : Monster
    {
        string name = "고블린";
        public string Name { get { return name; } }
        int hp = 200;
        int att = 130;
        public bool IsTurn { get; set; } = false;
        int[] loot;

        public int Hp
        {
            get { return hp; }
            set { hp = value; if (hp < 0) hp = 0; }
        }
        public int Att
        {
            get { return att; }
        }
        public int[] Loot
        {
            get { return loot; }
            //23:고블린의 옷자락 24:고블린의 손톱 25:고블린 고기
            set { loot = new int[] { 23, 24, 25 }; }
        }
        public void Attack(Player player)
        {
            player.HP -= Att;

            Console.WriteLine($"{Name}의 공격!");
            Thread.Sleep(1500);

            Console.WriteLine($"{player.Name}은/는 {Att}의 피해를 입었습니다!");
            Console.WriteLine($"나의 남은 체력: {player.HP}");
            Console.WriteLine("---------------");
            Thread.Sleep(1000);

        }

    }

    class Shop
    {
        //0:대검 1:도끼 2:망치 3:갑옷 4:목걸이 5:엘릭서
        int[] selllist = new int[] { 0, 1, 2, 3, 4, 5 };

        public void PrintSellList()
        {
            Console.WriteLine("========판매 목록========");
            for (int i = 0; i < selllist.Length; i++)
            {
                if (selllist[i] == 0) Console.Write($"{i}: 대검 ");
                else if (selllist[i] == 1) Console.Write($"{i}: 도끼 ");
                else if (selllist[i] == 2) Console.Write($"{i}: 망치 ");
                else if (selllist[i] == 3) Console.Write($"{i}: 갑옷 ");
                else if (selllist[i] == 4) Console.Write($"{i}: 목걸이 ");
                else if (selllist[i] == 5) Console.Write($"{i}: 엘릭서 10개 ");
            }
        }

        public void BuyItem(Player player)
        {
            player.CheckInven();
            if (player.IsInvenFull == true)
            {
                Console.WriteLine("인벤토리가 꽉찼습니다! ");
                return;
            }
            Console.Write("어떤 아이템을 구매하시겠습니까?: ");
            int buynum = int.Parse(Console.ReadLine());

            for (int i = 0; i < player.Inventory.Length; i++)
            {
                if (player.Inventory[i] == 9999)
                {
                    if (selllist[buynum] == 0)           //대검
                    {
                        if (player.Gold < 1200)
                        {
                            Console.WriteLine("골드가 부족합니다!");
                            return;
                        }
                        player.Gold -= 1200;
                        player.Inventory[i] = 0;
                        Console.WriteLine("구매 완료!");
                        Console.WriteLine($"현재 소지 금액: {player.Gold}");
                        player.EmptyCount--;
                        player.IsInvenEmpty = false;
                        player.CheckInven();
                        return;
                    }
                    else if (selllist[buynum] == 1)      //도끼
                    {
                        if (player.Gold < 1400)
                        {
                            Console.WriteLine("골드가 부족합니다!");
                            return;
                        }
                        player.Gold -= 1400;
                        player.Inventory[i] = 1;
                        Console.WriteLine("구매 완료!");
                        Console.WriteLine($"현재 소지 금액: {player.Gold}");
                        player.EmptyCount--;
                        player.IsInvenEmpty = false;
                        player.CheckInven();
                        return;
                    }
                    else if (selllist[buynum] == 2)      //망치
                    {
                        if (player.Gold < 1200)
                        {
                            Console.WriteLine("골드가 부족합니다!");
                            return;
                        }
                        player.Gold -= 1200;
                        player.Inventory[i] = 2;
                        Console.WriteLine("구매 완료!");
                        Console.WriteLine($"현재 소지 금액: {player.Gold}");
                        player.EmptyCount--;
                        player.IsInvenEmpty = false;
                        player.CheckInven();
                        return;
                    }
                    else if (selllist[buynum] == 3)      //갑옷
                    {
                        if (player.Gold < 1100)
                        {
                            Console.WriteLine("골드가 부족합니다!");
                            return;
                        }
                        player.Gold -= 1100;
                        player.Inventory[i] = 3;
                        Console.WriteLine("구매 완료!");
                        Console.WriteLine($"현재 소지 금액: {player.Gold}");
                        player.EmptyCount--;
                        player.IsInvenEmpty = false;
                        player.CheckInven();
                        return;
                    }
                    else if (selllist[buynum] == 4)      //목걸이
                    {
                        if (player.Gold < 1000)
                        {
                            Console.WriteLine("골드가 부족합니다!");
                            return;
                        }
                        player.Gold -= 1000;
                        player.Inventory[i] = 4;
                        Console.WriteLine("구매 완료!");
                        Console.WriteLine($"현재 소지 금액: {player.Gold}");
                        player.EmptyCount--;
                        player.IsInvenEmpty = false;
                        player.CheckInven();
                        return;
                    }
                    else if (selllist[buynum] == 5)      //엘릭서
                    {
                        if (player.Gold < 3000)
                        {
                            Console.WriteLine("골드가 부족합니다!");
                            return;
                        }
                        player.Gold -= 3000;
                        player.Inventory[i] = 5;
                        player.PotionCount += 10;
                        Console.WriteLine("구매 완료!");
                        Console.WriteLine($"현재 소지 금액: {player.Gold}");
                        player.EmptyCount--;
                        player.IsInvenEmpty = false;
                        player.CheckInven();
                        return;
                    }

                }
                else if (player.Inventory[i] != 0) continue;
            }
        }

        public void SellItem(Player player)
        {
            player.PrintMyInven();
            player.CheckInven();
            if (player.IsInvenEmpty == true)
            {
                Console.WriteLine("판매 가능한 아이템이 없습니다!");
                return;
            }
            Console.WriteLine("");
            Console.Write("어떤 아이템을 판매하시겠습니까?: ");
            int sellnum = int.Parse(Console.ReadLine());

            for (int i = 0; i < player.Inventory.Length; i++)
            {
                if (player.Inventory[i] != 9999)
                {
                    if (player.Inventory[sellnum] == 0)           //대검
                    {
                        player.Gold += 1200;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 1)      //도끼
                    {
                        player.Gold += 1400;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 2)      //망치
                    {
                        player.Gold += 1200;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 3)      //갑옷
                    {
                        player.Gold += 1100;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 4)      //목걸이
                    {
                        player.Gold += 900;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 5)      //엘릭서
                    {
                        player.Gold += 3000;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        player.PotionCount -= 10; // 포션 카운트 -10 반영
                        break;
                    }
                    else if (player.Inventory[sellnum] == 20)      //슬라임의 점액
                    {
                        player.Gold += 500;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 21)      //슬라임의 정수
                    {
                        player.Gold += 600;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 22)      //슬라임의 방울
                    {
                        player.Gold += 700;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 23)      //고블린의 옷자락
                    {
                        player.Gold += 600;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 24)      //고블린의 손톱
                    {
                        player.Gold += 700;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                    else if (player.Inventory[sellnum] == 25)      //고블린 고기
                    {
                        player.Gold += 300;
                        player.Inventory[sellnum] = 9999;
                        player.EmptyCount++;
                        break;
                    }
                }
            }
            Console.WriteLine("판매 완료!");
            Console.WriteLine($"현재 소지 금액: {player.Gold}");
            player.CheckInven();
            return;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Slime slime = new Slime();
            Goblin goblin = new Goblin();
            Shop shop = new Shop();

            player.InputName();
            player.InitializeInventory();
            while (true)
            {
                Random rand = new Random();
                int monstertype = rand.Next(1, 3);
                Console.Write("무엇을 하시겠습니까? (0)내 정보 (1)상점 (2)사냥: ");
                int action = int.Parse(Console.ReadLine());

                if (action == 0)
                {
                    Console.Write("무엇을 하시겠습니까? (0)현재 스탯 확인 (1)인벤토리 확인 (2)아이템 장착 (3)포션 사용 (4)돌아가기: ");
                    int action0 = int.Parse(Console.ReadLine());
                    if (action0 == 0)
                    {
                        player.PrintMyStat();
                        Thread.Sleep(1500);
                        continue;
                    }
                    else if (action0 == 1)
                    {
                        player.PrintMyInven();
                        Thread.Sleep(1500);
                        continue;
                    }
                    else if (action0 == 2)
                    {
                        player.EquipItem();
                        continue;
                    }
                    else if (action0 == 3)
                    {
                        player.UsePotion();
                        continue;
                    }
                    else if (action0 == 4) continue;
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }
                }
                else if (action == 1)
                {
                    Console.Write("상점에서 무엇을 하시겠습니까? (0)아이템 구매 (1)아이템 판매 (2)돌아가기: ");
                    int action1 = int.Parse(Console.ReadLine());
                    if (action1 == 0)
                    {
                        shop.PrintSellList();
                        shop.BuyItem(player);
                        continue;
                    }
                    else if (action1 == 1)
                    {
                        shop.SellItem(player);
                        continue;
                    }
                    else if (action1 == 2)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }
                }
                else if (action == 2)
                {
                    player.Battle(slime, goblin, monstertype);
                    player.ResetMonster(slime, goblin, monstertype);
                }
            }

        }
    }
}
