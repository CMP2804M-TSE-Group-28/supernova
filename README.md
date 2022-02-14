# TSE Group 28 - Game Project

✨ This repo is for the main Unity project 

| Property      | Value       |
|---------------|-------------|
| Unity Version | 2020.3.25f1 |
| LTS           | Yes         |

## Best Practises
 
### 🗣️ Commit Messages

- All commit messages must conform to [Convential Commits](https://www.conventionalcommits.org/) standard.

- In summary commits should look like:

```
<type>[optional scope (in brackets)]: <description>

[optional body]

[optional footer(s)]
```


### 🌴 Branching

- Each thing added must be done so in a **separate branch** to prevent merge conflits.

- Branches must be named in the format of `yourname/feature` (e.g. `cooperj/player-movement`). These can be incremented by appending numbers to the end.

- To create a new branch run the cmdlet `git checkout -b yourname/feature`.

### 👓 Code Reviews

- Issues and PRs must follow the standard templates.

- Until a PR is ready for review, it must have the label `draft`.

- Once it is ready, remove the `draft` label, and add the `requires-review` label.

- And then request a review from someone.

- Once you've reviewed a PR, remove the `requires-review` label to indicate that it is ready to merge.

- Once the review has been approved, the branch **must only** be merged by PR Assignee.

- PRs will always be into the `main` branch.

- Branches and PRs should be **locked** and **deleted** after merging. *This is only to be done by the PR Assignee.*

### 🚩 Issues

- When issues arise;

- Open an **issue** ticket on the **Github** repo.

- And then, add it to [the task list in Notion](https://www.notion.so/joshcuol/ea67374c885346b684680d48a9756680?v=c0d66886efc540d29006a5d30b4c5ace).

- **Only create a new issue if there is not one already.**

- New features should also be opened as an issue first.

- While working through an issue, you must **update your progress on the Notion Tracker**.

### 🔀 Pull Requests

- Pull requests must follow the same format as an issue.

- PRs should be **squashed and merged**.

### 🌍 The Main Branch

- The `main` branch is the *default branch* that is opened when visiting github.com or when cloning the repo.

- The `main` branch must **always** be ready for testing, and only contain known good code.
