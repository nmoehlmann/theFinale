export class Keep{
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.views = data.views
    // virtuals section below
    this.kept = data.kept
    this.creator = data.creator
  }
}