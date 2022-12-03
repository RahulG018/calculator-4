using SQLite;


namespace Calculator
{
    public class HistoryViewModel
    {

        string _dbPath;

        private SQLiteAsyncConnection conn;

        private string StatusMessage { get; set; }

        private async Task Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<HistoryItem>();
                 
        }



        public HistoryViewModel(string dbPath)
        {
            _dbPath = dbPath;

        }



        public async Task AddToHistory(string calculation)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(calculation))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                result = await conn.InsertAsync(new HistoryItem {  QuestionAnswer = calculation });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, calculation);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", calculation, ex.Message);
            }
        }

        public async Task<List<HistoryItem>> GetHistory()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                await Init();
                return await conn.Table<HistoryItem>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<HistoryItem>();
        }

        public async Task<int> DeleteHistory()
        {
            await Init();
            return await conn.DeleteAllAsync<HistoryItem>();

        }


        
    }
}
