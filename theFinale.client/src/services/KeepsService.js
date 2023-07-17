import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{
  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log(res.data, 'keeps res.data')
    AppState.keeps.push(new Keep(res.data))
    logger.log(AppState.keeps, 'keeps appstate')
  }

  async getAllKeeps(){
    const res = await api.get('api/keeps')
    logger.log(res.data, 'get res.data')
    AppState.keeps = res.data.map(k => new Keep(k))
    logger.log('keeps appstate', AppState.keeps)
  }

  async getKeepById(keepId){
    const res = await api.get(`api/keeps/${keepId}`)
    AppState.activeKeep = new Keep(res.data)
    logger.log(AppState.activeKeep)
  }

  async getUserKeeps(userId) {
    const res = await api.get(`api/profiles/${userId}/keeps`)
    logger.log(res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
    logger.log(AppState.keeps)
  }


}

export const keepsService = new KeepsService()