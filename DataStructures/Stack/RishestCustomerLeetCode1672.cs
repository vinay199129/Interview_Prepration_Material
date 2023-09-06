public int MaximumWealth(int[][] accounts)
{
    return accounts.Select(person => person.Sum()).Max();
}
