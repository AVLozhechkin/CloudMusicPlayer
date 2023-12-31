import {Component, inject} from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatExpansionModule} from "@angular/material/expansion";
import {MatInputModule} from "@angular/material/input";
import {FormControl, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {PlaylistsService} from "../../../core/services/playlists.service";
import {MatButtonModule} from "@angular/material/button";

@Component({
  selector: 'cmp-create-playlist-panel',
  standalone: true,
  imports: [CommonModule, MatExpansionModule, MatInputModule, FormsModule, ReactiveFormsModule, MatButtonModule],
  templateUrl: './create-playlist-panel.component.html'
})
export class CreatePlaylistPanelComponent {
  private playlistsService = inject(PlaylistsService)

  panelOpenState = false;
  playlistName = new FormControl("", [
    Validators.required,
    Validators.minLength(2)
  ])

  protected createTopic()
  {
    if (!this.playlistName.errors)
    {
      this.playlistsService.createPlaylist(this.playlistName.value!)
        .subscribe({
          next: playlist => {
            console.log('Created a playlist ' + playlist.id)
          },
          error: err => console.log(err)
        })
    }
  }
}
