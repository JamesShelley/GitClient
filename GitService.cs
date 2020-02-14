using LibGit2Sharp;
using System.Collections.Generic;

namespace GitClient.Services
{
    public class GitService : IGit
    {
        public string InitRepository(string repoLocation)
        {
            string message;
            if(!Repository.IsValid(repoLocation))
            {
                Repository.Init(@repoLocation);
                message = "Repo initialized successfully";
            } else
            {
                message = "This is already a Git Repository.";
            }
            return message;
        }

        public List<string> GetBranches(string repoLocation)
        {
            using (var repo = new Repository(@repoLocation))
            {
                var branches = repo.Branches;
                List<string> repoBranches = new List<string>();

                foreach (var branch in branches)
                {
                    repoBranches.Add(branch.FriendlyName);
                }

                if (repoBranches.Count == 0)
                {
                    repoBranches.Add("There are no branches in this repository.");
                }

                return repoBranches;
            }

        }

        public List<string> GetCommits(string repoLocation)
        {
            using (var repo = new Repository(@repoLocation))
            {
                var commits = repo.Commits;
                List<string> repoCommits = new List<string>();
                foreach(var commit in commits)
                {
                    repoCommits.Add(commit.Id.ToString() + " " + commit.MessageShort.ToString() + " " + commit.Author.ToString());
                }

                if (repoCommits.Count == 0)
                {
                    repoCommits.Add("No commits have been made in this repository.");
                }

                return repoCommits;
            }
        }

        public Commit FindCommit(string repoLocation, string commitId)
        {
            using (var repo = new Repository(@repoLocation))
            {
                var commit = repo.Lookup<Commit>(commitId);
                return commit;
            }
        }

        public Commit GetLatestCommit(string repoLocation)
        {
            using (var repo = new Repository(@repoLocation))
            {
                var latesCommit = repo.Head.Tip;
                return latesCommit;
            }
        }

        public List<string> GetTags(string repoLocation) 
        { 
            using (var repo = new Repository(@repoLocation))
            {
                var tags = repo.Tags;
                List<string> tagList = new List<string>();
                foreach(var tag in tags)
                {
                    tagList.Add(tag.FriendlyName + " " + tag.Target.Id);
                }

                if(tagList.Count == 0)
                {
                    tagList.Add("There are no associated tags in this repository.");
                }

                return tagList;
            }
        }

        public void CreateBranch(string repoLocation, string branchName)
        {
            using (var repo = new Repository(@repoLocation))
            {
                repo.CreateBranch(branchName);
            }
        }

        public void MakeCommit(string repoLocation, string commitMessage, string authorName, string branchName)
        {
            
        }

        public List<string> GetRepoIndex(string repoLocation)
        {
            using (var repo = new Repository(@repoLocation))
            {
                var index = repo.Index;
                List<string> indexList = new List<string>();
                foreach (var i in index)
                {
                    indexList.Add("Blob: " + i.Id.ToString() + ", Path: " + i.Path + ", File Mode:" + i.Mode + ", Stage Number:" + i.StageLevel);
                }

                if (indexList.Count == 0)
                {
                    indexList.Add("No changes have been made");
                }

                return indexList;
            }
        }

    }
}
