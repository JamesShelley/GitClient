using LibGit2Sharp;
using System.Collections.Generic;

namespace GitClient.Services
{
    public class GitService : IGit
    {
        public void InitRepository(string repoLocation)
        {
            if(!Repository.IsValid(repoLocation))
            {
                Repository.Init(@repoLocation);
            } 
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

    }
}
