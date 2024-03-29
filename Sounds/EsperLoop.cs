using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;

namespace EsperClass.Sounds
{
	public class EsperLoop : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			// By checking if the input soundInstance is playing, we can prevent the sound from firing while the sound is still playing, allowing the sound to play out completely. Non-ModSound behavior is to restart the sound, only permitting 1 instance.
			if (soundInstance.State == SoundState.Playing)
			{
				return null;
			}
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * 1f;
			//soundInstance.IsLooped = true;
			return soundInstance;
		}
	}
}
