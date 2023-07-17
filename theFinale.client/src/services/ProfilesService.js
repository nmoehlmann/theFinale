import {Account} from '../models/Account'
import { api } from './AxiosService'
class ProfilesService {
    async getProfileById(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        AppState.profile = new Account(res.data)
        logger.log(AppState.profile)
    }
}

export const profilesService = new ProfilesService()