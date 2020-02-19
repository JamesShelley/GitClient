using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitClient.Services
{
    public interface IGit 
    { 
        string InitRepository(string repoLocation);
        List<string> GetBranches(string repoLocation);
        List<string> GetCommits(string repoLocation);
        Commit FindCommit(string repoLocation, string commitId);
        Commit GetLatestCommit(string repoLocation);
        List<string> GetTags(string repoLocation);
        void CreateBranch(string repoLocation, string branchName);
        List<string> GetRepoIndex(string repoLocation);
        List<string> GetStatus(string repoLocation); 

    }
}
