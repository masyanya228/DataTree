using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataTree.tech
{
    public static class MYDBe
    {
        static Random ran = new Random();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] Add(this MYDBo obj, string name, string value = "")
        {
            MYDBo[] ot = new MYDBo[2];
            ot[0] = obj;
            ot[1] = obj.link.Add(name, value, obj.Adress);
            return ot;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] Add(this MYDBo[] obj, string name, string value = "", Picker parentPic = Picker.Last)
        {
            MYDBo[] ot = new MYDBo[obj.Length + 1];
            for (int i = 0; i < obj.Length; i++) ot[i] = obj[i];
            if (parentPic == Picker.First)
                ot[ot.Length - 1] = obj[0].link.Add(name, value, obj[0].Adress);
            else if (parentPic == Picker.Last)
                ot[ot.Length - 1] = obj[obj.Length - 1].link.Add(name, value, obj[obj.Length - 1].Adress);
            else if (parentPic == Picker.Last)
                ot[ot.Length - 1] = obj[ran.Next(0, obj.Length)].link.Add(name, value, obj[ran.Next(0, obj.Length)].Adress);
            return ot;
        }
        public enum Picker
        {
            First,
            Last,
            Random
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        /*public MYDBo Add(string name, string val, string parent)
        {
            string ot = GetAdd();
            MYDBo ret = null;
            string parName = "0";
            if (ot != "null")
            {
                BinaryWriter w = null;
                try
                {
                    w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                    w.BaseStream.Seek(0, SeekOrigin.End);
                    if (parent != "")
                        parName = parent;
                    w.Write("x" + parName);
                    w.Write("x" + ot);
                    w.Write(name + ":" + val);
                    ret = AddTable(parName, ot, name, val, w.BaseStream.Position);
                    all++;
                    w.Close();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    return null;
                }
                finally
                {
                    if (w != null)
                        w.Close();
                }
            }
            return ret;
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] Get(this MYDBo[] array, string addr)
        {
            if (array == null) return null;
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Adress == addr)
                    ot.Add(array[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] GetByParent(this MYDBo[] array, string parentAddr)
        {
            if (array == null) return null;
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ParentAdress == parentAddr)
                    ot.Add(array[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] GetByName(this MYDBo[] array, string Name)
        {
            if (array == null) return null;
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Name == Name)
                    ot.Add(array[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] GetByValue(this MYDBo[] array, string Value)
        {
            if (array == null) return null;
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Value == Value)
                    ot.Add(array[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo GetLast(this MYDBo[] array)
        {
            if (array == null) return null;
            if (array.Length == 0)
            {
                return null;
            }
            else
            {
                return array[array.Length - 1];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo GetRandom(this MYDBo[] array)
        {
            if (array == null) return null;
            if (array.Length == 0)
            {
                return null;
            }
            else
            {
                return array[ran.Next(0, array.Length)];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] Slice(this MYDBo[] array, int start, int end = -1)
        {
            if (end == -1) end = array.Length;
            if (array == null) return null;
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = start; i <= end & i < array.Length; i++)
            {
                ot.Add(array[i]);
            }
            return ot.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] Split(this MYDBo[] array, int start, int len = -1)
        {
            if (len == -1) len = array.Length - start;
            if (array == null) return null;
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = start; i < start + len & i < array.Length; i++)
            {
                ot.Add(array[i]);
            }
            return ot.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] GetChilds(this MYDBo[] array, MYDBo[] from = null)
        {
            if (array == null) return null;
            if (array.Length == 0)
                return new MYDBo[0];
            if (from == null) from = array[0].link.tables.ToArray();
            List<MYDBo> ot = new List<MYDBo>();
            for (int n = 0; n < from.Length; n++)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Adress == from[n].ParentAdress)
                        ot.Add(from[n]);
                }
            }
            return ot.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] GetChilds(this MYDBo obj, MYDBo[] from = null)
        {
            if (obj == null) return null;
            if (from == null) from = obj.link.tables.ToArray();
            List<MYDBo> ot = new List<MYDBo>();
            for (int n = 0; n < from.Length; n++)
            {
                if (obj.Adress == from[n].ParentAdress)
                    ot.Add(from[n]);
            }
            return ot.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="parentAddr"></param>
        /// <returns></returns>
        public static MYDBo[] toArray(this MYDBo obj)
        {
            if (obj == null) return null;
            return new MYDBo[1] { obj };
        }
    }
    public class MYDB
    {
        public BinaryWriter w;
        public void Close()
        {

        }
        public List<MYDBo> tables = new List<MYDBo>();
        public List<UInt64[]> freeadd = new List<UInt64[]>();
        public uint all = 0;
        public string path = Environment.CurrentDirectory + "\\BD1.tower";
        public bool Readed = false;
        public MYDB(string path, bool read = true)
        {
            this.path = path;
            if (read)
            {
                Load();
            }
        }

        public MYDBo Add(string name, string parent = "0")
        {
            return Add(name, "", parent);
        }
        public MYDBo Add(string name, string val, string parent)
        {
            string ot = GetAdd();
            MYDBo ret = null;
            string parName = "0";
            if (ot != "null")
            {
                //BinaryWriter w = null;
                try
                {
                    if (w == null)
                        w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                    w.BaseStream.Seek(0, SeekOrigin.End);
                    if (parent != "")
                        parName = parent;
                    w.Write("x" + parName);
                    w.Write("x" + ot);
                    w.Write(name + ":" + val);
                    ret = AddTable(parName, ot, name, val, w.BaseStream.Position);
                    all++;
                    w.Close();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    return null;
                }
                finally
                {
                    if (w != null)
                        w.Close();
                }
            }
            return ret;
        }

        MYDBo AddTable(string parent, string adr, string name, string value, long offset)
        {
            lock (all as object)
            {
                /*parent = parent.Substring(1);
                adr = adr.Substring(1);*/
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].Adress == adr)
                    {
                        if (parent == "-1")
                        {
                            RemoveTable(adr);
                            return null;
                        }
                        else
                        {
                            tables[i].Name = name;
                            tables[i].Value = value;
                            return tables[i];
                        }
                    }
                }
                MYDBo ns = new MYDBo(parent, adr, name, value, offset, this);
                RemoveFree(adr);
                tables.Add(ns);
                //RemoveFree(adr);
                return ns;
            }
        }

        public string[] Remove(string addr, bool delchild = true)
        {
            List<string> addrs = new List<string>();
            addrs.Add(addr);
            if (delchild)
            {
                List<string> unch = new List<string>();
                unch.Add(addr);
                int alle = 0;
                for (; unch.Count > 0 & alle < tables.Count; )
                {
                    for (int i = 0; i < tables.Count; i++)
                        if (tables[i].Parent.Adress == unch[0])
                        {
                            if (tables[i].Adress != tables[i].Parent.Adress)
                                addrs.Add(tables[i].Adress);
                            alle++;
                            if (unch.IndexOf(tables[i].Adress) == -1)
                                unch.Add(tables[i].Adress);
                        }
                    unch.RemoveAt(0);
                }
            }
            try
            {
                BinaryWriter w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                w.BaseStream.Seek(0, SeekOrigin.End);
                for (int i = 0; i < addrs.Count; i++)
                {
                    if (RemoveTable(addrs[i]))
                    {
                        w.Write("x-1");
                        w.Write("x" + addrs[i]);
                        w.Write("x");
                        all++;
                    }
                    else
                    {
                        Console.WriteLine("/" + addrs[i] + " -not find");
                    }
                }
                w.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("/Del error");
                return addrs.ToArray();
            }
            return addrs.ToArray();
        }
        public MYDBo Set(string addr, string name, string value)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Adress == addr)
                {
                    try
                    {
                        tables[i].Name = name;
                        tables[i].Value = value;
                        BinaryWriter w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                        w.BaseStream.Seek(0, SeekOrigin.End);
                        w.Write("x" + tables[i].Parent);
                        w.Write("x" + addr);
                        w.Write(name + ":" + value);
                        w.Close();
                        all++;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    return tables[i];
                }
            }
            return null;
        }
        public MYDBo Set(string addr, string value)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Adress == addr)
                {
                    try
                    {
                        tables[i].Value = value;
                        BinaryWriter w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                        w.BaseStream.Seek(0, SeekOrigin.End);
                        w.Write("x" + tables[i].Parent);
                        w.Write("x" + addr);
                        w.Write(tables[i].Name + ":" + value);
                        w.Close();
                        all++;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    return tables[i];
                }
            }
            return null;
        }
        public MYDBo SetPar(string addr, string parent)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Adress == addr)
                {
                    try
                    {
                        //MYDBo parentlink = Get(parent);
                        if (tables[i].ParentAdress != parent)
                        {
                            MYDBo parentlink = Get(parent);
                            tables[i].ParentAdress = parent;
                            tables[i].Parent = parentlink;
                        }
                        BinaryWriter w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                        w.BaseStream.Seek(0, SeekOrigin.End);
                        w.Write("x" + tables[i].Parent);
                        w.Write("x" + addr);
                        w.Write(tables[i].Name + ":" + tables[i].Value);
                        w.Close();
                        all++;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    return tables[i];
                }
            }
            return null;
        }

        public MYDBo Get(string addr)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Adress == addr)
                    return tables[i];
            }
            return null;
        }

        public MYDBo[] GetByParent(string parentAddr)
        {
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Parent.Adress == parentAddr)
                    ot.Add(tables[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }

        public MYDBo[] GetByName(string Name)
        {
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Name == Name)
                    ot.Add(tables[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }

        public MYDBo[] GetByValue(string Value)
        {
            List<MYDBo> ot = new List<MYDBo>();
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Value == Value)
                    ot.Add(tables[i]);
            }
            if (ot.Count == 0)
            {
                return ot.ToArray();
            }
            else
            {
                return ot.ToArray();
            }
        }



        bool RemoveTable(string addr)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Adress == addr)
                {
                    tables.RemoveAt(i);
                    ReturnFree(addr);
                    return true;
                }
            }
            return false;
        }
        string GetAdd()
        {
            string ot = "";
            if (freeadd.Count > 0)
            {
                ot = freeadd[0][0].ToString();
                if (freeadd[0][0] == freeadd[0][1])
                    freeadd.RemoveAt(0);
                else freeadd[0][0]++;
            }
            else
            {
                ot = "null";
            }
            return ot;
        }
        string ReturnFree(string add)
        {
            UInt64 addr = 0;
            if (UInt64.TryParse(add, out addr))
            {
                for (int i = 0; i < freeadd.Count; i++)
                {
                    if (i > 0)
                        if (freeadd[i - 1][1] + 1 == addr & freeadd[i][0] - 1 == addr)
                        {
                            freeadd[i - 1][1] = freeadd[i][1];
                            freeadd.RemoveAt(i);
                            return "";
                        }
                    if (freeadd[i][1] + 1 == addr)
                    {
                        freeadd[i][1]++;
                        return "";
                    }
                    else if (freeadd[i][0] - 1 == addr)
                    {
                        freeadd[i][0]--;
                        return "";
                    }
                    if (addr < freeadd[i][0])
                    {
                        freeadd.Insert(i, new UInt64[] { addr, addr });
                        return "";
                    }
                }
            }
            return "err";
        }
        string RemoveFree(string add)
        {
            UInt64 addr = 0;
            if (UInt64.TryParse(add, out addr))
            {
                for (int i = 0; i < freeadd.Count; i++)
                {
                    if (freeadd[i][0] <= addr & freeadd[i][1] >= addr)
                    {
                        if (freeadd[i][0] == freeadd[i][1])
                        {
                            freeadd.RemoveAt(i);
                        }
                        else if (freeadd[i][0] == addr)
                        {
                            freeadd[i][0]++;
                        }
                        else if (freeadd[i][1] == addr)
                        {
                            freeadd[i][1]--;
                        }
                        else
                        {
                            freeadd.Insert(i + 1, new UInt64[] { addr + 1, freeadd[i][1] });
                            freeadd[i][1] = addr - 1;
                        }
                        return "";
                    }
                }
            }
            return "err";
        }
        public void PrintAll()
        {
            for (int i = 0; i < tables.Count; i++)
            {
                Console.WriteLine(tables[i].Parent + " " + tables[i].Adress + " " + tables[i].Name + " " + tables[i].Value + " " + tables[i].offset);
            }
        }

        public static string[] GetDataBase(string folder)
        {
            try
            {
                return Directory.GetFiles(folder, "*.tower");
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public void Load()
        {
            Readed = true;
            tables.Clear();
            all = 0;
            freeadd = new List<ulong[]>();
            freeadd.Add(new ulong[] { 1, UInt32.MaxValue });
        a: try
            {
                BinaryReader r = new BinaryReader(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                try
                {
                    for (int i = 0; ; i++)
                    {
                        int b = r.PeekChar();
                        if (r.PeekChar() != -1)
                        {
                            all++;
                            string s1 = r.ReadString();
                            string s2 = r.ReadString();
                            string s3 = r.ReadString();
                            string s4 = "";
                            s1 = s1.Substring(1);
                            s2 = s2.Substring(1);
                            string[] nv = s3.Split(new string[] { ":" }, 2, StringSplitOptions.None);
                            if (nv.Length == 2)
                            {
                                s3 = nv[0];
                                s4 = nv[1];
                            }
                            else if (nv.Length == 1)
                            {
                                s3 = nv[0];
                            }
                            else
                            {
                                s3 = "";
                            }
                            AddTable(s1, s2, s3, s4, r.BaseStream.Position);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IOException ex)
                {

                }
                finally
                {
                    r.Close();
                }
            }
            catch (IOException ex)
            {
                goto a;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (all > 0)
                Console.WriteLine("White: " + Math.Round(tables.Count / (decimal)all * 100M, 1) + "%");
            else
                Console.WriteLine("База данных пуста");
        }
        public string AcceptChanges()
        {
            BinaryWriter w = null;
            try
            {
                File.Move(path, path + ".old");
                w = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.UTF8);
                for (int i = 0; i < tables.Count; i++)
                {
                    w.Write("x" + tables[i].Parent);
                    w.Write("x" + tables[i].Adress);
                    w.Write(tables[i].Name + ":" + tables[i].Value);
                }
                w.Close();
                return "/accepted";
            }
            catch (Exception ex)
            {
                if (w != null)
                    w.Close();
                return "/err";
            }
            finally
            {

            }
        }
        public string ClearOld()
        {
            try
            {
                string[] old = Directory.GetFiles(new FileInfo(path).DirectoryName, "*.old");
                for (int i = 0; i < old.Length; i++)
                {
                    if (old[i].EndsWith(".tower.old"))
                    {
                        File.Delete(old[i]);
                        Console.WriteLine(old[i].Substring(old[i].LastIndexOf('\\') + 1) + " -deleted");
                    }
                }
                return "/cleared";
            }
            catch (Exception ex)
            {
                return "/err";
            }
            finally
            {

            }
        }
    }

    public class MYDBo
    {
        public MYDBo Parent;
        public string ParentAdress;
        public string Adress;
        public string Name;
        public string Value;
        public string type;
        public long offset;

        public MYDB link;


        public MYDBo(string parent, string adr, string name, string value, long offset, MYDB link)
        {
            this.Name = name;
            this.Value = value;
            //this.Parent = parentlink;
            this.ParentAdress = parent;
            this.Adress = adr;
            this.offset = offset;
            this.link = link;
        }
    }
}