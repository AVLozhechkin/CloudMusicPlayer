import {Song} from "./song.model";

export interface Playlist {
  id: string,
  name: string,
  createdAt: Date,
  updatedAt: Date,
  songFiles: Song[] | null
}
