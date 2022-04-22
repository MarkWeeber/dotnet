using System;
using System.IO;
using System.Text;

namespace app7
{
    struct Staff
    {
        private int id;
        public int ID
        {
            get {return id;}
            set {id = value;}
        }
        private DateTime recordDate;
        public DateTime RecordDate
        {
            get {return recordDate;}
        }
        private string fullName;
        public string FullName
        {
            get {return fullName;}
        }
        private int age;
        public int Age
        {
            get {return age;}
        }
        private int reach;
        public int Reach
        {
            get {return reach;}
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get {return dateOfBirth;}
        }
        private string birthPlace;
        public string BirthPlace
        {
            get {return birthPlace;}
        }
        public Staff(int id, DateTime recordDate, string fullName, int age, DateTime dateOfBirth, int reach, string birthPlace)
        {
            this.id = id;
            this.recordDate = recordDate;
            this.fullName = fullName;
            this.age = age;
            this.dateOfBirth = dateOfBirth;
            this.reach = reach;
            this.birthPlace = birthPlace;
        }
        public Staff(DateTime recordDate, string fullName, int age, DateTime dateOfBirth, int reach, string birthPlace) :
        this(-1, DateTime.Now, fullName,  age,  dateOfBirth,  reach,  birthPlace)
        {
            
        }
        public Staff(string fullName, int age, DateTime dateOfBirth, int reach, string birthPlace) :
        this(DateTime.Now, fullName,  age,  dateOfBirth,  reach,  birthPlace)
        {
            
        }
        public string ReadStaff()
        {
            return id + "#" + recordDate + "#" + fullName + "#" + age + "#" + dateOfBirth + "#" + reach + "#" + birthPlace;
        }
        
    }

    struct StaffRepository
    {
        private Staff[] repo;
        private string pathToFile;
        private string fileName;
        private string filePath;
        private bool fileLoaded;
        public StaffRepository(string pathToFile, string fileName)
        {
            repo = new Staff[0];
            fileLoaded = false;
            this.pathToFile = pathToFile;
            this.fileName = fileName;
            this.filePath = pathToFile + fileName;
        }
        private void LoadRepository()
        {
            fileLoaded = false;
            repo = new Staff[0];
            if (File.Exists(filePath))
            {
                int rowCount = 0;
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.Unicode))
                {
                    // get size of file
                    while (streamReader.ReadLine() != null)
                    {
                        rowCount++;
                    }
                }
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.Unicode))
                {
                    // resize arrays
                    Array.Resize(ref repo, rowCount);
                    // copy the data
                    for (int i = 0; i < rowCount; i++)
                    {
                        string[] rowData = streamReader.ReadLine().Split("#");
                        repo[i] = new Staff(
                            int.Parse(rowData[0]),
                            DateTime.Parse(rowData[1]),
                            rowData[2],
                            int.Parse(rowData[3]),
                            DateTime.Parse(rowData[4]),
                            int.Parse(rowData[5]),
                            rowData[6]
                        );
                    }
                }
                fileLoaded = true;
            }
        }

        public Staff ReadRepository(int index)
        {
            LoadRepository(); // try to load file
            if(!fileLoaded) // if still no file found
            {
                return repo[Array.IndexOf(repo, index)];
            }
            else
            {
                return new Staff();
            }
        }

        public Staff[] ReadRepository()
        {
            LoadRepository(); // try to load file
            if(fileLoaded)
            {
                return repo;
            }
            else
            {
                return new Staff[0];
            }
        }

        public Staff[] ReadRepository(DateTime dateFrom, DateTime dateTo)
        {
            LoadRepository(); // try to load file
            if(fileLoaded)
            {
                int size = repo.Length;
                Staff[] ans = new Staff[size];
                int actuallSize = 0;
                for (int i = 0; i < repo.Length; i++)
                {
                    if (repo[i].RecordDate > dateFrom && repo[i].RecordDate < dateTo)
                    {
                        ans[actuallSize] = repo[i];
                        actuallSize++;
                    }
                }
                Array.Resize(ref ans, actuallSize);
                return ans;
            }
            else
            {
                return new Staff[0];
            }
        }

        public void AddStaff(Staff staff)
        {
            LoadRepository(); // try to load file
            if(!fileLoaded) // if still no file found
            {
                Directory.CreateDirectory(pathToFile); // create new file
                File.Create(filePath).Close();
                repo = new Staff[0];
            }
            int size = repo.Length;
            staff.ID = GetLastIncrementor()+1;
            Array.Resize(ref repo, size+1);
            repo[size] = staff; 
            // now record to file
            using (StreamWriter streamWriter = new StreamWriter (filePath, true, Encoding.Unicode))
            {
                streamWriter.WriteLine(repo[size].ReadStaff());
            }
        }

        private int GetLastIncrementor()
        {
            int ans = -1;
            LoadRepository();
            for (int i = 0; i < repo.Length; i++)
            {
                if(repo[i].ID > ans)
                {
                    ans = repo[i].ID;
                }
            }
            return ans;
        }
        public void EditStaff(int index, Staff staff)
        {
            int staffId = repo[index].ID;
            repo[index] = staff;
            repo[index].ID = staffId;
            // clean file
            File.WriteAllText(filePath, String.Empty);
            using (StreamWriter streamWriter = new StreamWriter (filePath, true, Encoding.Unicode))
            {
                // add each new line
                foreach (Staff item in repo)
                {
                    streamWriter.WriteLine(item.ReadStaff());
                }
            }
        }

        public void DeleteStaff(int index)
        {
            // prepare new repo
            int size = repo.Length;
            for (int i = index; i < size - 1; i++)
            {
                repo[i] = repo[i+1];
            }
            Array.Resize(ref repo, size - 1);
            // clean file
            File.WriteAllText(filePath, String.Empty);
            using (StreamWriter streamWriter = new StreamWriter (filePath, true, Encoding.Unicode))
            {
                // add each new line
                foreach (Staff item in repo)
                {
                    streamWriter.WriteLine(item.ReadStaff());
                }
            }
        }

        public int RepoSize()
        {
            int ans = -1;
            return repo.Length;
        }

        public void SortById(bool ascending = true)
        {
            if(ascending)
            {
                for (int i = repo.Length; i >= 0; i--)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if(repo[j].ID > repo[j+1].ID)
                        {
                            Staff temp = repo[j];
                            repo[j] = repo[j + 1];
                            repo[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = repo.Length; i >= 0; i--)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if(repo[j].ID < repo[j+1].ID)
                        {
                            Staff temp = repo[j];
                            repo[j] = repo[j + 1];
                            repo[j + 1] = temp;
                        }
                    }
                }
            }
            ResetRepo();
        }

        public void SortByRecordDates(bool ascending = true)
        {
            if(ascending)
            {
                for (int i = repo.Length; i >= 0; i--)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if(DateTime.Compare(repo[j].RecordDate, repo[j+1].RecordDate) > 0)
                        {
                            Staff temp = repo[j];
                            repo[j] = repo[j + 1];
                            repo[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = repo.Length; i >= 0; i--)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if(DateTime.Compare(repo[j].RecordDate, repo[j+1].RecordDate) < 0)
                        {
                            Staff temp = repo[j];
                            repo[j] = repo[j + 1];
                            repo[j + 1] = temp;
                        }
                    }
                }
            }
            ResetRepo();
        }
        public void SortByBirthDates(bool ascending = true)
        {
            if(ascending)
            {
                for (int i = repo.Length; i >= 0; i--)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if(DateTime.Compare(repo[j].DateOfBirth, repo[j+1].DateOfBirth) > 0)
                        {
                            Staff temp = repo[j];
                            repo[j] = repo[j + 1];
                            repo[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = repo.Length; i >= 0; i--)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if(DateTime.Compare(repo[j].DateOfBirth, repo[j+1].DateOfBirth) < 0)
                        {
                            Staff temp = repo[j];
                            repo[j] = repo[j + 1];
                            repo[j + 1] = temp;
                        }
                    }
                }
            }
            ResetRepo();
        }

        private void ResetRepo()
        {
            // clean file
            File.WriteAllText(filePath, String.Empty);
            using (StreamWriter streamWriter = new StreamWriter (filePath, true, Encoding.Unicode))
            {
                // add each new line
                foreach (Staff item in repo)
                {
                    streamWriter.WriteLine(item.ReadStaff());
                }
            }
        }
    }
}