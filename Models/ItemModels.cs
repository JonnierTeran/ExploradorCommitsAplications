using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExploradorCommitsApp.Models
{
    public class ItemModels
    {
        public int id { get; set; } = int.MaxValue;
        public string node_id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string full_name { get; set; } = string.Empty;
        public bool @private { get; set; }
        public OwnerModels owner { get; set; } = new OwnerModels();
        public string html_url { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public bool fork { get; set; }
        public string url { get; set; } = string.Empty;
        public string forks_url { get; set; } = string.Empty;
        public string keys_url { get; set; } = string.Empty;
        public string collaborators_url { get; set; } = string.Empty;
        public string teams_url { get; set; } = string.Empty;
        public string hooks_url { get; set; } = string.Empty;
        public string issue_events_url { get; set; } = string.Empty;
        public string events_url { get; set; } = string.Empty;
        public string assignees_url { get; set; } = string.Empty;
        public string branches_url { get; set; } = string.Empty;
        public string tags_url { get; set; } = string.Empty;
        public string blobs_url { get; set; } = string.Empty;
        public string git_tags_url { get; set; } = string.Empty;
        public string git_refs_url { get; set; } = string.Empty;
        public string trees_url { get; set; } = string.Empty;
        public string statuses_url { get; set; } = string.Empty;
        public string languages_url { get; set; } = string.Empty;
        public string stargazers_url { get; set; } = string.Empty;
        public string contributors_url { get; set; } = string.Empty;
        public string subscribers_url { get; set; } = string.Empty;
        public string subscription_url { get; set; } = string.Empty;
        public string commits_url { get; set; } = string.Empty;
        public string git_commits_url { get; set; } = string.Empty;
        public string comments_url { get; set; } = string.Empty;
        public string issue_comment_url { get; set; } = string.Empty;
        public string contents_url { get; set; } = string.Empty;
        public string compare_url { get; set; } = string.Empty;
        public string merges_url { get; set; } = string.Empty;
        public string archive_url { get; set; } = string.Empty;
        public string downloads_url { get; set; } = string.Empty;
        public string issues_url { get; set; } = string.Empty;
        public string pulls_url { get; set; } = string.Empty;
        public string milestones_url { get; set; } = string.Empty;
        public string notifications_url { get; set; } = string.Empty;
        public string labels_url { get; set; } = string.Empty;
        public string releases_url { get; set; } = string.Empty;
        public string deployments_url { get; set; } = string.Empty;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }
        public string git_url { get; set; } = string.Empty;
        public string ssh_url { get; set; } = string.Empty;
        public string clone_url { get; set; } = string.Empty;
        public string svn_url { get; set; } = string.Empty;
        public string homepage { get; set; } = string.Empty;
        public int size { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public string language { get; set; } = string.Empty;
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_downloads { get; set; }
        public bool has_wiki { get; set; }
        public bool has_pages { get; set; }
        public bool has_discussions { get; set; }
        public int forks_count { get; set; }
        public object? mirror_url { get; set; }
        public bool archived { get; set; }
        public bool disabled { get; set; }
        public int open_issues_count { get; set; }
        public LicenceModels license { get; set; } = new LicenceModels();
        public bool allow_forking { get; set; }
        public bool is_template { get; set; }
        public bool web_commit_signoff_required { get; set; }
        public string[]? topics { get; set; }
        public string visibility { get; set; } = string.Empty;
        public int forks { get; set; }
        public int open_issues { get; set; }
        public int watchers { get; set; }
        public string default_branch { get; set; } = string.Empty;      
        public double score { get; set; } = double.MaxValue;
    }
}
